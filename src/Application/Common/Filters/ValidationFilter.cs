using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Application.Common.Filters;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray());

            context.Result = new BadRequestObjectResult(new
            {
                Message = "Validación fallida",
                Errors = errors
            });
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // No hay necesidad de validación
    }
}