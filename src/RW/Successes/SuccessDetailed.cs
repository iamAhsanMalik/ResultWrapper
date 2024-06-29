using RW.Models;

namespace RW.Successes;

public sealed class SuccessDetailed<T> : IResultWrapper<T>
{
    public SuccessDetailed(object? payload, string successMessage, int successCode, Pagination? paginationInfo)
    {
        Payload = payload;
        Message = successMessage;
        Code = successCode;
        PaginationInfo = paginationInfo;
    }
    bool IBaseResult.IsSuccess { get; set; } = true;
    public string Message { get; set; }
    public int Code { get; set; }
    public Pagination? PaginationInfo { get; set; }
    public object? Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
}
