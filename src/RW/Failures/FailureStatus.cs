namespace RW.Failures;

public class FailureStatus<T> : IResultWrapper<T>
{
    bool IBaseResult.IsSuccess { get; set; }
    public FailureStatus(string errorMessage, int errorCode)
    {
        Message = errorMessage;
        Code = errorCode;
    }

    public string Message { get; set; }
    public int Code { get; set; }
    object? IResultWrapper.Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
}
