using RW.Extensions;

namespace RW;

public interface IBaseResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
}

public interface IResultWrapper : IBaseResult
{
    object? Payload { get; set; }
    object? Errors { get; set; }
    T? TypedPayload<T>() => Payload.PayloadConversion<T>();
}

public interface IResultWrapper<T> : IResultWrapper { }
