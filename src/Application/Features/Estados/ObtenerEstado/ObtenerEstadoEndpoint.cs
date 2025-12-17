using Contracts.Estado;

namespace Application.Features.Estados.ObtenerEstado;

public static class ObtenerEstadoEndpoint
{
    public static IEndpointRouteBuilder MapObtenerEstado(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/estados/{id:int}", async (
            int id,
            ObtenerEstadoService service) =>
        {
            if (id == 0) return Results.BadRequest(new { error = "ID invalido" });

            var result = await service.ObtenerPorIdAsync(id);

            return result.EsExitoso
                ? Results.Ok(result.Valor)
                : Results.NotFound(result.Error);
        })
        .WithName("ObtenerEstado")
        .WithTags("Estado")
        .Produces<EstadoResponse>(200)
        .Produces(404)
        .Produces(400);

        return app;
    }
}