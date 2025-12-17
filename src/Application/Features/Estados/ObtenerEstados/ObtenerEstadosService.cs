using Contracts.Common;
using Contracts.Estado;
using DemoV3.Contracts.Common;
using Domain.Repositories;

namespace Application.Features.Estados.ObtenerEstados;

public class ObtenerEstadosService(IEstadoRepository repository)
{
    private readonly IEstadoRepository _repository = repository;

    public async Task<Resultado<IEnumerable<EstadoResponse>>> ObtenerTodosAsync()
    {
        try
        {
            var estados = await _repository.ObtenerTodosAsync();

            var responses = estados.Select(estado => new EstadoResponse(
                estado.Id,
                estado.Nombre,
                estado.Descripcion.Valor,
                estado.TipoEstado.ToString(),
                estado.CreatedAt,
                estado.UpdatedAt
            ));

            return Resultado<IEnumerable<EstadoResponse>>.Exitoso(responses);
        }
        catch (Exception ex)
        {
            return Resultado<IEnumerable<EstadoResponse>>.Fallido(
                new Error("Estado.Error", ex.Message));
        }
    }
}