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
