using RW.Extensions;

namespace RW;

public interface IBaseResult
{
    public string Message { get; set; }
    public int Code { get; set; }
}

public interface IResultWrapper<T> : IBaseResult
{
    public bool IsSuccess { get; set; }
    T? Payload { get; set; }
    T? Errors { get; set; }
    T? TypedPayload() => Payload.PayloadConversion<T>();
}

public interface IResultWrapper : IResultWrapper<object>
{
}
