using System.Net;

namespace Application.Common.Result;

public static class ResultadoExtensions
{
    public static Resultado<TOut> Bind<TIn, TOut>(
        this Resultado<TIn> result,
        Func<TIn, Resultado<TOut>> func)
    {
        if (!result.Success)
            return Resultado<TOut>.Fail(
                result.Error!,
                result.StatusCode);

        try
        {
            return func(result.Data!);
        }
        catch (Exception ex)
        {
            return ExceptionMapper.MapToResult<TOut>(ex);
        }
    }

    public static async Task<Resultado<TOut>> Bind<TIn, TOut>(
        this Resultado<TIn> result,
        Func<TIn, Task<Resultado<TOut>>> func)
    {
        if (!result.Success)
            return Resultado<TOut>.Fail(
                result.Error!,
                result.StatusCode);

        try
        {
            return await func(result.Data!);
        }
        catch (Exception ex)
        {
            return ExceptionMapper.MapToResult<TOut>(ex);
        }
    }

    public static async Task<Resultado<TOut>> Bind<TIn, TOut>(
        this Task<Resultado<TIn>> result,
        Func<TIn, Task<Resultado<TOut>>> func)
    {
        try
        {
            Resultado<TIn> resultResolved = await result;
            if (!resultResolved.Success)
                return Resultado<TOut>.Fail(
                    resultResolved.Error!,
                    resultResolved.StatusCode);
            return await func(resultResolved.Data!);
        }
        catch (Exception ex)
        {
            return ExceptionMapper.MapToResult<TOut>(ex);
        }
    }

    public static async Task<Resultado<TOut>> Bind<TIn, TOut>(
        this Task<Resultado<TIn>> result,
        Func<TIn, Resultado<TOut>> func)
    {
        try
        {
            Resultado<TIn> resultResolved = await result;
            if (!resultResolved.Success)
                return Resultado<TOut>.Fail(
                    resultResolved.Error!,
                    resultResolved.StatusCode);
            return func(resultResolved.Data!);
        }
        catch (Exception ex)
        {
            return ExceptionMapper.MapToResult<TOut>(ex);
        }
    }

    public static Resultado<TOut> Map<TIn, TOut>(
        this Resultado<TIn> result,
        Func<TIn, TOut> func)
    {
        if (!result.Success)
            return Resultado<TOut>.Fail(
                result.Error!,
                result.StatusCode);

        try
        {
            return func(result.Data!);
        }
        catch (Exception ex)
        {
            return ExceptionMapper.MapToResult<TOut>(ex);
        }
    }

    public static Resultado<T> Tap<T>(
        this Resultado<T> result,
        Action<T> action)
    {
        if (result.Success)
            action(result.Data!);

        return result;
    }

    public static Resultado<T> Ensure<T>(
        this Resultado<T> result,
        Func<T, bool> predicate,
        Error error,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        if (!result.Success)
            return result;

        if (!predicate(result.Data!))
            return Resultado<T>.Fail(error, statusCode);

        return result;
    }
}

