using RW.Common;
using RW.Models;

namespace RW.Successes;

public sealed class SuccessPaginated<T> : IResultWrapper<T>
{
    public SuccessPaginated(T? payload, Pagination? paginationInfo)
    {
        Payload = payload;
        PaginationInfo = paginationInfo;
        ((IResultWrapper)this).Payload = payload;
    }
    bool IResultBase.IsSuccess { get; set; } = true;
    string IResultBase.Message { get; set; } = string.Empty;
    int IResultBase.Code { get; set; }
    public Pagination? PaginationInfo { get; set; }
    public T? Payload { get; set; }
    T? IResultWrapper<T>.Errors { get; set; }
    object? IResultWrapper.Payload { get; set; }
    object? IResultWrapper.Errors { get; set; }
}
