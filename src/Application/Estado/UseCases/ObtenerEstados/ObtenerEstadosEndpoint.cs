using DemoV3.Contracts.Estados;

namespace DemoV3.Application.Estados.UseCases.ObtenerEstados;

public static class ObtenerEstadosEndpoint
{
    public static IEndpointRouteBuilder MapObtenerEstados(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/v1/estados", async (
            ObtenerEstadosService service) =>
        {
            var result = await service.ObtenerTodosAsync();

            return result.EsExitoso
                ? Results.Ok(result.Valor)
                : Results.BadRequest(result.Error);
        })
        .WithName("ObtenerEstados")
        .WithTags("Estados")
        .Produces<IEnumerable<EstadoResponse>>(200)
        .Produces(400);

        return app;
    }
}