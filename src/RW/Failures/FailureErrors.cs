using RW;
using RW.Common;

namespace RW.Failures;

/// <summary>
/// Represents a failure result of an operation with errors only.
/// </summary>
/// <typeparam name="T">The type of the errors.</typeparam>
public class FailureErrors<T> : IResultWrapper<T>
{
    /// <inheritdoc/>
    bool IResultBase.IsSuccess { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FailureErrors{T}"/> class.
    /// </summary>
    /// <param name="errors">The errors associated with the failure.</param>
    public FailureErrors(T? errors = default)
    {
        Errors = errors;
        ((IResultWrapper)this).Errors = errors;
    }

    /// <inheritdoc/>
    string IResultBase.Message { get; set; } = string.Empty;

    /// <inheritdoc/>
    int IResultBase.Code { get; set; }

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
