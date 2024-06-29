namespace RW.Successes;
public sealed class SuccessEmpty<T> : IResultWrapper<T>
{
    object? IResultWrapper.Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
    bool IBaseResult.IsSuccess { get; set; } = true;
    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
}
