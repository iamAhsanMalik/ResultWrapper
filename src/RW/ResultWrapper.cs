using RW.Models;

using RW.Failures;
using RW.Successes;

namespace RW;

/// <summary>
/// A static class that provides methods for creating service result responses.
/// </summary>
public static class ResultWrapper
{
    public static IResultWrapper Success()
    {
        return new SuccessEmpty<object>();
    }
    public static IResultWrapper Success(object? payload)
    {
        return new SuccessPayload<object>(payload);
    }
    public static IResultWrapper Success(string message, int code)
    {
        return new SuccessStatus<object>(message, code);
    }
    public static IResultWrapper Success(object? payload, string message, int code)
    {
        return new SuccessPayloadStatus<object>(payload, message, code);
    }
    public static IResultWrapper Success(object? payload, Pagination paginationInfo)
    {
        return new SuccessPaginated<object>(payload, paginationInfo);
    }
    public static IResultWrapper Success(object? payload, Pagination paginationInfo, string message, int code)
    {
        return new SuccessDetailed<object>(payload, message, code, paginationInfo);
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
