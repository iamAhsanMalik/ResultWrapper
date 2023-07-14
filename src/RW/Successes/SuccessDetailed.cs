using RW.Common;
using RW.Models;

namespace RW.Successes;

public sealed class SuccessDetailed<T> : IResultWrapper<T>
{
    public SuccessDetailed(T? payload, string successMessage, int successCode, Pagination? paginationInfo)
    {
        Payload = payload;
        Message = successMessage;
        Code = successCode;
        PaginationInfo = paginationInfo;
        ((IResultWrapper)this).Payload = payload;
    }
    bool IResultBase.IsSuccess { get; set; } = true;
    public string Message { get; set; }
    public int Code { get; set; }
    public T? Payload { get; set; }
    public Pagination? PaginationInfo { get; set; }
    T? IResultWrapper<T>.Errors { get; set; }
    object? IResultWrapper.Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
}
