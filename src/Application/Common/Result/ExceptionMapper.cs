using System.Net;

namespace Application.Common.Result
{
    public static class ExceptionMapper
    {
        public static Resultado<T> MapToResult<T>(Exception ex)
        {
            return ex switch
            {
                ArgumentNullException => Resultado<T>.Fail(
                    Error.NullValue,
                    HttpStatusCode.BadRequest),

                ArgumentException => Resultado<T>.Fail(
                    new Error("Error.InvalidArgument", ex.Message),
                    HttpStatusCode.BadRequest),

                InvalidOperationException => Resultado<T>.Fail(
                    new Error("Error.InvalidOperation", ex.Message),
                    HttpStatusCode.Conflict),

                TimeoutException => Resultado<T>.Fail(
                    new Error("Error.Timeout", "El servicio no respondió"),
                    HttpStatusCode.ServiceUnavailable),

                _ => Resultado<T>.Fail(
                    new Error("Error.Unexpected", "Error interno del servidor"),
                    HttpStatusCode.InternalServerError)
            };
        }
    }
}
