namespace RW.Successes;

public sealed class SuccessPayload<T> : IResultWrapper<T>
{
    bool IBaseResult.IsSuccess { get; set; } = true;
    public SuccessPayload(object? payload)
    {
        Payload = payload;
    }
    public object? Payload { get; set; }
    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
    object? IResultWrapper.Errors { get; set; }
}
