using DemoV3.Domain.Entities;

namespace DemoV3.Contracts.Interfaces;

public interface IEstadoRepository
{
    Task<Estado?> ObtenerPorIdAsync(int id);
    Task<Estado?> ObtenerPorNombreAsync(string nombre);
    Task<IEnumerable<Estado>> ObtenerTodosAsync();
    Task AgregarAsync(Estado estado);
    Task ActualizarAsync(Estado estado);
}