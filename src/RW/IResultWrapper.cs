using System.Text.Json.Serialization;

using RW.Common;

namespace RW;

/// <summary>
/// Represents the result of a service operation.
/// </summary>
public interface IResultWrapper : IResultBase
{
    /// <summary>
    /// Gets or sets the payload associated with the service result.
    /// </summary>
    [JsonIgnore]
    object? Payload { get; set; }

    /// <summary>
    /// Gets or sets the errors associated with the service result.
    /// </summary>
    [JsonIgnore]
    object? Errors { get; set; }

    /// <summary>
    /// Obtain the typed payload, even when using a non-generic result wrapper.
    /// </summary>
    /// <typeparam name="T">The type of the payload.</typeparam>
    /// <returns>The typed payload if available; otherwise, null.</returns>
    T? TypedPayload<T>()
    {
        return Payload is T typedPayload ? typedPayload : TypeConversion<T>();
    }

    private T? TypeConversion<T>()
    {
        Type targetType = typeof(T);

        if (Payload is not null && targetType.IsArray && typeof(T).GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
        {
            var list = (System.Collections.IList)Payload!;
            var array = Array.CreateInstance(targetType.GetElementType()!, list.Count);
            list.CopyTo(array, 0);
            return (T)Convert.ChangeType(array, targetType);
        }

        return default!;
    }
}
/// <summary>
/// Represents the result of a service operation.
/// </summary>
/// <typeparam name="T">The type of the payload or error.</typeparam>
public interface IResultWrapper<T> : IResultWrapper
{
    /// <summary>
    /// Gets or sets the data associated with the service result.
    /// </summary>
    new T? Payload { get; set; }

    /// <summary>
    /// Gets or sets the errors associated with the service result.
    /// </summary>
    new T? Errors { get; set; }
}
