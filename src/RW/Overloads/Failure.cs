namespace RW.Overloads;
public class FailureDetailed<T> : IResultWrapper
{
    public FailureDetailed(T? errors, string message, int code)
    {
        Errors = errors;
        Message = message;
        Code = code;
        ((IResultWrapper)this).Errors = errors;
    }
    bool IResultWrapper<object>.IsSuccess { get; set; } = false;
    public string Message { get; set; }
    public int Code { get; set; }
    public object? Errors { get; set; }
    object? IResultWrapper<object>.Payload { get; set; }
}
public class FailureEmpty<T> : IResultWrapper
{
    object? IResultWrapper<object>.Errors { get; set; }
    object? IResultWrapper<object>.Payload { get; set; }
    bool IResultWrapper<object>.IsSuccess { get; set; } = false;
    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
}
public class FailureErrors<T> : IResultWrapper
{
    bool IResultWrapper<object>.IsSuccess { get; set; } = false;
    public FailureErrors(T? errors)
    {
        Errors = errors;
        ((IResultWrapper)this).Errors = errors;
    }
    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
    public object? Errors { get; set; }
    object? IResultWrapper<object>.Payload { get; set; }
}
public class FailureStatus<T> : IResultWrapper
{
    bool IResultWrapper<object>.IsSuccess { get; set; } = false;
    public FailureStatus(string errorMessage, int errorCode)
    {
        Message = errorMessage;
        Code = errorCode;
    }

    public string Message { get; set; }
    public int Code { get; set; }
    object? IResultWrapper<object>.Errors { get; set; }
    object? IResultWrapper<object>.Payload { get; set; }
}
