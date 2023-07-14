using RW.Common;

namespace RW.Successes;

public sealed class SuccessPayload<T> : IResultWrapper<T>
{
    bool IResultBase.IsSuccess { get; set; } = true;
    public SuccessPayload(T? payload = default)
    {
        Payload = payload;
        ((IResultWrapper)this).Payload = payload;
    }
    public T? Payload { get; set; }
    T? IResultWrapper<T>.Errors { get; set; }
    string IResultBase.Message { get; set; } = string.Empty;
    int IResultBase.Code { get; set; }
    object? IResultWrapper.Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
}
