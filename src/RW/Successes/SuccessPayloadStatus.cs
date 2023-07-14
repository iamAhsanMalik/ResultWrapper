using RW.Common;

namespace RW.Successes;
public sealed class SuccessPayloadStatus<T> : IResultWrapper<T>
{
    public SuccessPayloadStatus(T? payload, string successMessage, int successCode)
    {
        Payload = payload;
        Message = successMessage;
        Code = successCode;
        ((IResultWrapper)this).Payload = payload;
    }
    bool IResultBase.IsSuccess { get; set; } = true;
    public T? Payload { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
    T? IResultWrapper<T>.Errors { get; set; }
    object? IResultWrapper.Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
}
