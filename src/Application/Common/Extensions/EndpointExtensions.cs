namespace DemoV3.Application.Common.Extensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapEstadosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/estados").WithTags("Estados");
        return group;
    }
}