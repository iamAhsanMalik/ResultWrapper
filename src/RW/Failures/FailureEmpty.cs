namespace RW.Failures;

public class FailureEmpty<T> : IResultWrapper<T>
{
    object? IResultWrapper.Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
    bool IBaseResult.IsSuccess { get; set; }
    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
}
