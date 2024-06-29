using RW.Models;

namespace RW.Successes;

public sealed class SuccessPaginated<T> : IResultWrapper<T>
{
    public SuccessPaginated(object? payload, Pagination? paginationInfo)
    {
        Payload = payload;
        PaginationInfo = paginationInfo;
    }
    bool IBaseResult.IsSuccess { get; set; } = true;
    string IBaseResult.Message { get; set; } = string.Empty;
    int IBaseResult.Code { get; set; }
    public Pagination? PaginationInfo { get; set; }
    public object? Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
}
