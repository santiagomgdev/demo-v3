using DemoV3.Contracts.Common;
using System.Net;
using System.Text.Json.Serialization;

namespace Application.Common.Result;

public class Resultado<T>
{
    public bool Success { get; }
    public T? Data { get; }
    public Error? Error { get; }
    [JsonIgnore]
    public HttpStatusCode StatusCode {  get; }

    private Resultado(bool success, T? data, Error? error, HttpStatusCode statusCode)
    {
        Success = success;
        Data = data;
        Error = error;
        StatusCode = statusCode;
    }

    public static implicit operator Resultado<T>(T value)
    {
        return Resultado<T>.Ok(value);
    }

    public static Resultado<T> Ok(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
        => new(true, data, Error.None, statusCode);

    public static Resultado<T> Fail(Error error, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(false, default, error, statusCode);

    public static Resultado<T> NotFound(Error error, HttpStatusCode statusCode = HttpStatusCode.NotFound)
        => new(false, default, error, statusCode);

    public static Resultado<T> Forbidden(Error error, HttpStatusCode statusCode = HttpStatusCode.Forbidden)
        => new(false, default, error, statusCode);

    public static Resultado<T> InternalServerError(Error error, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        => new(false, default, error, statusCode);
}
