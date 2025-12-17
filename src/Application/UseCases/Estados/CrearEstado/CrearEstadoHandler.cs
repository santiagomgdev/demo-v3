using Contracts.Common;
using Contracts.Estado;
using DemoV3.Contracts.Common;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Features.Estados.CrearEstado;

public class CrearEstadoHandler(IEstadoRepository repository)
{
    private readonly IEstadoRepository _repository = repository;
    
    public async Task<Resultado<CrearEstadoResponse>> Handle(CrearEstadoRequest request)
    {
        try
        {
            // Validar que ningún otro estado exista con el mismo nombre
            var estadoExistente = await _repository.ObtenerPorNombreAsync(request.Nombre);
            if (estadoExistente is not null)
                return Resultado<CrearEstadoResponse>.Fallido(
                    new Error("Estado.Duplicado", "Un estado con ese nombre ya existe"));

            var estado = Estado.Crear(
            request.Nombre,
            request.Descripcion);

            await _repository.AgregarAsync(estado);

            var response = new CrearEstadoResponse(
                estado.Id,
                estado.Nombre,
                estado.Descripcion.Valor,
                estado.TipoEstado.ToString(),
                estado.CreatedAt);

            return Resultado<CrearEstadoResponse>.Exitoso(response);
        }
        catch (Exception ex)
        {
            return Resultado<CrearEstadoResponse>.Fallido(
                new Error("Estado.Error", ex.Message));
        }
    }
}