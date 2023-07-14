using RW;
using RW.Common;

namespace RW.Failures;

/// <summary>
/// Represents a failure result of an operation without errors.
/// </summary>
/// <typeparam name="T">The type of the errors.</typeparam>
public class FailureStatus<T> : IResultWrapper<T>
{
    /// <inheritdoc/>
    bool IResultBase.IsSuccess { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FailureStatus{T}"/> class with the specified error message and error code.
    /// </summary>
    /// <param name="errorMessage">The error message.</param>
    /// <param name="errorCode">The error code.</param>
    public FailureStatus(string errorMessage, int errorCode)
    {
        Message = errorMessage;
        Code = errorCode;
    }

    /// <summary>
    /// Gets or sets the error message associated with the failure result.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the error code associated with the failure result.
    /// </summary>
    public int Code { get; set; }

    /// <inheritdoc/>
    T? IResultWrapper<T>.Payload { get; set; }

    /// <inheritdoc/>
    T? IResultWrapper<T>.Errors { get; set; }

    /// <inheritdoc/>
    object? IResultWrapper.Payload { get; set; }

    /// <inheritdoc/>
    object? IResultWrapper.Errors { get; set; }
}
