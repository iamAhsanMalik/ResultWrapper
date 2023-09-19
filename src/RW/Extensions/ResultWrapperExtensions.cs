namespace RW.Extensions;
public static class ResultWrapperExtensions
{
    public static T? PayloadConversion<T>(this object? payload)
    {
        if (payload is T typedPayload)
        {
            return typedPayload;
        }

        var sourceType = payload!.GetType();

        if (IsEnumerable(sourceType) && IsEnumerable(typeof(T)))
        {
            if (ShouldConvertToArray(sourceType, typeof(T)))
            {
                return ConvertToArray<T>(payload);
            }
            else if (ShouldConvertToList(sourceType))
            {
                return ConvertToList<T>(payload);
            }
        }

        return default!;
    }

    private static bool ShouldConvertToArray(Type sourceType, Type targetType)
    {
        return targetType.IsArray && sourceType.IsArray && !typeof(System.Collections.IEnumerable).IsAssignableFrom(sourceType);
    }

    private static bool ShouldConvertToList(Type sourceType)
    {
        return typeof(System.Collections.IEnumerable).IsAssignableFrom(sourceType);
    }

    private static T ConvertToArray<T>(object payload)
    {
        var elementType = typeof(T).GetElementType();
        var list = (System.Collections.IList)payload!;
        var array = ListToArray(list, elementType);
        return (T)(object)array;
    }

    private static T ConvertToList<T>(object payload)
    {
        var genericArgumentType = payload!.GetType().GetGenericArguments()[0];
        var toListMethod = typeof(Enumerable).GetMethod("ToList");
        var toListGenericType = toListMethod!.MakeGenericMethod(genericArgumentType);
        var list = toListGenericType.Invoke(null, new object[] { payload });

        if (typeof(T).IsArray)
        {
            var toArrayMethod = typeof(Enumerable).GetMethod("ToArray")?.MakeGenericMethod(genericArgumentType);
            var array = toArrayMethod?.Invoke(null, new object[] { list! });
            return (T)array!;
        }

        return (T)list!;
    }

    private static bool IsEnumerable(Type? sourceType)
    {
        return sourceType?.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>)) == true;
    }

    private static Array ListToArray(System.Collections.IList list, Type? elementType)
    {
        var array = Array.CreateInstance(elementType!, list.Count);
        list.CopyTo(array, 0);
        return array;
    }
}

