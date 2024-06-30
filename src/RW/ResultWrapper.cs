using RW.Models;
using RW.Overloads;

namespace RW;

/// <summary>
/// A static class that provides methods for creating service result responses.
/// </summary>
public static class ResultWrapper
{
    public static IResultWrapper Success<T>()
    {
        return new SuccessEmpty<T>();
    }
    public static IResultWrapper Success<T>(T? payload)
    {
        return new SuccessPayload<T>(payload);
    }
    public static IResultWrapper Success<T>(string message, int code)
    {
        return new SuccessStatus<T>(message, code);
    }
    public static IResultWrapper Success<T>(T? payload, string message, int code)
    {
        return new SuccessPayloadStatus<T>(payload, message, code);
    }
    public static IResultWrapper Success<T>(T? payload, Pagination paginationInfo)
    {
        return new SuccessPaginated<T>(payload, paginationInfo);
    }
    public static IResultWrapper Success<T>(T? payload, Pagination paginationInfo, string message, int code)
    {
        return new SuccessDetailed<T>(payload, message, code, paginationInfo);
    }

    public static IResultWrapper Failure()
    {
        return new FailureEmpty<object>();
    }
    public static IResultWrapper Failure(string message, int code)
    {
        return new FailureStatus<object>(message, code);
    }
    public static IResultWrapper Failure(object? errors)
    {
        return new FailureErrors<object>(errors);
    }
    public static IResultWrapper Failure(string message, int code, object? errors)
    {
        return new FailureDetailed<object>(errors, message, code);
    }
}
