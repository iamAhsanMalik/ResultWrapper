using RW;
using RW.Common;

namespace RW.Failures;

public class FailureEmpty<T> : IResultWrapper<T>
{
    T? IResultWrapper<T>.Payload { get; set; }
    object? IResultWrapper.Payload { get; set; }
    T? IResultWrapper<T>.Errors { get; set; }
    object? IResultWrapper.Errors { get; set; }
    bool IResultBase.IsSuccess { get; set; }
    string IResultBase.Message { get; set; } = string.Empty;
    int IResultBase.Code { get; set; }
}
