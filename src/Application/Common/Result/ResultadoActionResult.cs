using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Common.Result;


public static class ResultadoActionResult
{

    public static async Task<IActionResult> ToActionResult<T>(this Task<Resultado<T>> result)
    {
        return (await result).ToActionResult();
    }

    public static IActionResult ToActionResult<T>(
    this Resultado<T> result)
    {
        if (result.Success)
        {
            return result.StatusCode switch
            {
                HttpStatusCode.Created => new CreatedResult(string.Empty, result.Data),
                HttpStatusCode.NoContent => new NoContentResult(),
                _ => new OkObjectResult(result.Data)
            };
        }

        var problemDetails = new ProblemDetails
        {
            Status = (int)result.StatusCode,
            Title = result.Error?.Codigo,
            Detail = result.Error?.Mensaje
        };

        return new ObjectResult(problemDetails)
        {
            StatusCode = (int)result.StatusCode
        };
    }
}

