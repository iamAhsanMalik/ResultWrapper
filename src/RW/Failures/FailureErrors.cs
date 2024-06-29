namespace RW.Failures;

public class FailureErrors<T> : IResultWrapper<T>
{
    bool IBaseResult.IsSuccess { get; set; }

    public FailureErrors(object? errors)
    {
        Errors = errors;
    }

    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
    public object? Errors { get; set; }
    object? IResultWrapper.Payload { get; set; }
}
