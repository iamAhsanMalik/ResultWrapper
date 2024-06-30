using RW.Models;

namespace RW.Overloads;
public sealed class SuccessPaginated<T> : IResultWrapper
{
    public SuccessPaginated(T? payload, Pagination? paginationInfo)
    {
        Payload = payload;
        PaginationInfo = paginationInfo;
        ((IResultWrapper)this).Payload = payload;
    }
    bool IResultWrapper<object>.IsSuccess { get; set; } = true;
    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
    public Pagination? PaginationInfo { get; set; }
    public T? Payload { get; set; }
    object? IResultWrapper<object>.Errors { get; set; }
    object? IResultWrapper<object>.Payload { get; set; }
}
public sealed class SuccessDetailed<T> : IResultWrapper
{
    public SuccessDetailed(T? payload, string successMessage, int successCode, Pagination? paginationInfo)
    {
        Payload = payload;
        Message = successMessage;
        Code = successCode;
        PaginationInfo = paginationInfo;
        ((IResultWrapper)this).Payload = payload;
    }
    bool IResultWrapper<object>.IsSuccess { get; set; } = true;
    public string Message { get; set; }
    public int Code { get; set; }
    public Pagination? PaginationInfo { get; set; }
    public T? Payload { get; set; }
    object? IResultWrapper<object>.Errors { get; set; }
    object? IResultWrapper<object>.Payload { get; set; }
}
public sealed class SuccessEmpty<T> : IResultWrapper
{
    object? IResultWrapper<object>.Payload { get; set; }
    bool IResultWrapper<object>.IsSuccess { get; set; } = true;
    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
    object? IResultWrapper<object>.Errors { get; set; }
}

public sealed class SuccessPayload<T> : IResultWrapper
{
    bool IResultWrapper<object>.IsSuccess { get; set; } = true;
    public SuccessPayload(T? payload)
    {
        Payload = payload;
        ((IResultWrapper)this).Payload = payload;
    }
    public T? Payload { get; set; }
    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
    object? IResultWrapper<object>.Errors { get; set; }
    object? IResultWrapper<object>.Payload { get; set; }
}

public sealed class SuccessPayloadStatus<T> : IResultWrapper
{
    public SuccessPayloadStatus(T? payload, string successMessage, int successCode)
    {
        Payload = payload;
        Message = successMessage;
        Code = successCode;
        ((IResultWrapper)this).Payload = payload;
    }
    bool IResultWrapper<object>.IsSuccess { get; set; } = true;
    public string Message { get; set; }
    public int Code { get; set; }
    public T? Payload { get; set; }
    object? IResultWrapper<object>.Errors { get; set; }
    object? IResultWrapper<object>.Payload { get; set; }
}

public class SuccessStatus<T> : IResultWrapper
{
    bool IResultWrapper<object>.IsSuccess { get; set; } = true;
    public SuccessStatus(string successMessage, int successCode)
    {
        Message = successMessage;
        Code = successCode;
    }
    public string Message { get; set; }
    public int Code { get; set; }
    object? IResultWrapper<object>.Payload { get; set; }
    object? IResultWrapper<object>.Errors { get; set; }
}
