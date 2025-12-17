using Contracts.Estado;

namespace Application.Features.Estados.CrearEstado;

public static class CrearEstadoEndpoint
{
    public static IEndpointRouteBuilder MapCrearEstado(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/estados", async (
            CrearEstadoRequest request,
            CrearEstadoHandler handler,
            CrearEstadoValidator validator) =>
        {
            var resultadoValidacion = await validator.ValidateAsync(request);
            if (!resultadoValidacion.IsValid)
                return Results.BadRequest(resultadoValidacion.Errors);

            var resultado = await handler.Handle(request);

            return resultado.EsExitoso
                ? Results.Created($"/api/v1/estados/{resultado.Valor!.Id}", resultado.Valor)
                : Results.BadRequest(resultado.Error);
        })
        .WithName("CrearEstado")
        .WithTags("Estados");

        return app;
    }
}