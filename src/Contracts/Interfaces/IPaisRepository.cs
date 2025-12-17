using DemoV3.Domain.Entities;

namespace DemoV3.Contracts.Interfaces;

public interface IPaisRepository
{
    Task<Pais?> ObtenerPorIdAsync(int id);
    Task<Pais?> ObtenerPorNombreAsync(string nombre);
    Task<IEnumerable<Pais>> ObtenerTodosAsync();
    Task AgregarAsync(Pais pais);
    Task ActualizarAsync(Pais pais);
}