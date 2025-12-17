using Domain.Entities;

namespace Domain.Repositories;

public interface IEstadoRepository
{
    Task<Estado?> ObtenerPorIdAsync(int id);
    Task<Estado?> ObtenerPorNombreAsync(string nombre);
    Task<IEnumerable<Estado>> ObtenerTodosAsync();
    Task AgregarAsync(Estado estado);
    Task ActualizarAsync(Estado estado);
}