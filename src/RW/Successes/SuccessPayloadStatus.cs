namespace RW.Successes;
public sealed class SuccessPayloadStatus<T> : IResultWrapper<T>
{
    public SuccessPayloadStatus(object? payload, string successMessage, int successCode)
    {
        Payload = payload;
        Message = successMessage;
        Code = successCode;
    }
    bool IBaseResult.IsSuccess { get; set; } = true;
    public string Message { get; set; }
    public int Code { get; set; }
    public object? Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
}
