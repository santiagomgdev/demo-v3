using Domain.Entities;

namespace Domain.Repositories;

public interface IPaisRepository
{
    Task<Pais?> ObtenerPorIdAsync(int id);
    Task<Pais?> ObtenerPorNombreAsync(string nombre);
    Task<IEnumerable<Pais>> ObtenerTodosAsync();
    Task AgregarAsync(Pais pais);
    Task ActualizarAsync(Pais pais);
}