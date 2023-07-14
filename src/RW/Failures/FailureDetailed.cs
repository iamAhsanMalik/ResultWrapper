using RW;
using RW.Common;

namespace RW.Failures;

/// <summary>
/// Represents a failure result of an operation with errors.
/// </summary>
/// <typeparam name="T">The type of the errors.</typeparam>
public class FailureDetailed<T> : IResultWrapper<T>
{
    public FailureDetailed(T? errors, string message, int code)
    {
        Errors = errors;
        Message = message;
        Code = code;
        ((IResultWrapper)this).Errors = errors;
    }
    /// <inheritdoc/>
    bool IResultBase.IsSuccess { get; set; }

    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the error code associated with the failure result.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Gets or sets the errors associated with the failure result.
    /// </summary>
    public T? Errors { get; set; }

    /// <inheritdoc/>
    T? IResultWrapper<T>.Payload { get; set; }

    /// <inheritdoc/>
    object? IResultWrapper.Payload { get; set; }

    /// <inheritdoc/>
    object? IResultWrapper.Errors { get; set; }
}
