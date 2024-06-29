namespace RW.Failures;

public class FailureDetailed<T> : IResultWrapper<T>
{
    public FailureDetailed(object? errors, string message, int code)
    {
        Errors = errors;    
        Message = message;
        Code = code;
    }
    bool IBaseResult.IsSuccess { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
    public object? Errors { get; set; }
    object? IResultWrapper.Payload { get; set; }
}
