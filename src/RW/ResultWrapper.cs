using RW.Models;

using RW.Failures;
using RW.Successes;

namespace RW;

/// <summary>
/// A static class that provides methods for creating service result responses.
/// </summary>
public static class ResultWrapper
{
    // Generic overloads for success
    public static IResultWrapper<TPayload> Success<TPayload>()
    {
        return new SuccessEmpty<TPayload>();
    }
    public static IResultWrapper<TPayload> Success<TPayload>(TPayload? payload)
    {
        return new SuccessPayload<TPayload>(payload);
    }
    public static IResultWrapper<TPayload> Success<TPayload>(string message, int code)
    {
        return new SuccessStatus<TPayload>(message, code);
    }
    public static IResultWrapper<TPayload> Success<TPayload>(TPayload? payload, string message, int code)
    {
        return new SuccessPayloadStatus<TPayload>(payload, message, code);
    }
    public static IResultWrapper<TPayload> Success<TPayload>(TPayload? payload, Pagination paginationInfo)
    {
        return new SuccessPaginated<TPayload>(payload, paginationInfo);
    }
    public static IResultWrapper<TPayload> Success<TPayload>(TPayload? payload, Pagination paginationInfo, string message, int code)
    {
        return new SuccessDetailed<TPayload>(payload, message, code, paginationInfo);
    }

    // Non-Generic overloads for success
    public static IResultWrapper Success()
    {
        return new SuccessEmpty<object>();
    }
    public static IResultWrapper Success<TPayload>(object? payload)
    {
        return new SuccessPayload<object>(payload);
    }
    public static IResultWrapper Success(string message, int code)
    {
        return new SuccessStatus<object>(message, code);
    }
    public static IResultWrapper Success<TPayload>(object? payload, string message, int code)
    {
        return new SuccessPayloadStatus<object>(payload, message, code);
    }
    public static IResultWrapper Success<TPayload>(object? payload, Pagination paginationInfo)
    {
        return new SuccessPaginated<object>(payload, paginationInfo);
    }
    public static IResultWrapper Success<TPayload>(object? payload, Pagination paginationInfo, string message, int code)
    {
        return new SuccessDetailed<object>(payload, message, code, paginationInfo);
    }

    // Generic overloads for failure
    public static IResultWrapper<TErrors> Failure<TErrors>()
    {
        return new FailureEmpty<TErrors>();
    }
    public static IResultWrapper<TErrors> Failure<TErrors>(string message, int code)
    {
        return new FailureStatus<TErrors>(message, code);
    }
    public static IResultWrapper<TErrors> Failure<TErrors>(TErrors? errors)
    {
        return new FailureErrors<TErrors>(errors);
    }
    public static IResultWrapper<TErrors> Failure<TErrors>(string message, int code, TErrors? errors)
    {
        return new FailureDetailed<TErrors>(errors, message, code);
    }

    // Non-Generic overloads for failure
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
