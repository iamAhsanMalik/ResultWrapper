using RW;
using RW.Common;

namespace RW.Successes;
public sealed class SuccessEmpty<T> : IResultWrapper<T>
{
    public SuccessEmpty() { }
    T? IResultWrapper<T>.Payload { get; set; }
    object? IResultWrapper.Payload { get; set; }
    T? IResultWrapper<T>.Errors { get; set; }
    object? IResultWrapper.Errors { get; set; }
    bool IResultBase.IsSuccess { get; set; } = true;
    string IResultBase.Message { get; set; } = string.Empty;
    int IResultBase.Code { get; set; }
}
