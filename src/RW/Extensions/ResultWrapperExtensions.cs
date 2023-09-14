namespace RW.Extensions;
public static class ResultWrapperExtensions
{
    /// <summary>
    /// Convert loosly typed payload to strongly typed payload. However Properties of both objects should be same
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="payload"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static T ConvertToType<T>(this object payload)
    {
        ArgumentNullException.ThrowIfNull(payload);

        var targetType = typeof(T);
        var sourceType = payload.GetType();

        if (targetType.IsAssignableFrom(sourceType))
        {
            var instance = (T)Activator.CreateInstance(targetType)!;

            foreach (var property in targetType.GetProperties())
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                var sourceProperty = sourceType.GetProperty(property.Name);

                if (sourceProperty is null || !sourceProperty.CanRead)
                {
                    continue;
                }

                property.SetValue(instance, sourceProperty.GetValue(payload));
            }
            return instance;
        }

        throw new ArgumentException($"Can't convert {sourceType.FullName} to {targetType.FullName}");
    }
}
