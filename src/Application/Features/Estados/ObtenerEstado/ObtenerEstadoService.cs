using Contracts.Common;
using Contracts.Estado;
using DemoV3.Contracts.Common;
using Domain.Repositories;

namespace Application.Features.Estados.ObtenerEstado;

public class ObtenerEstadoService(IEstadoRepository repository)
{
    private readonly IEstadoRepository _repository = repository;

    public async Task<Resultado<EstadoResponse>> ObtenerPorIdAsync(int id)
    {
        try
        {
            var estado = await _repository.ObtenerPorIdAsync(id);

            if (estado is null) return Resultado<EstadoResponse>.Fallido(
                new Error("Estado.NoEncontrado", $"Estado con ID {id} no fue encontrado"));

            var response = new EstadoResponse(
                estado.Id,
                estado.Nombre,
                estado.Descripcion.Valor,
                estado.TipoEstado.ToString(),
                estado.CreatedAt,
                estado.UpdatedAt
            );

            return Resultado<EstadoResponse>.Exitoso(response);
        }
        catch (Exception ex)
        {
            return Resultado<EstadoResponse>.Fallido(
                new Error("Estado.Error", ex.Message));
        }
    }
}