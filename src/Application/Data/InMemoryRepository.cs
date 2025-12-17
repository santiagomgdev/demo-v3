using Domain.Entities;
using Domain.Repositories;

namespace Application.Data;

public class InMemoryRepository : IEstadoRepository
{
    private readonly List<Estado> _estados = [];

    public Task<Estado?> ObtenerPorIdAsync(int id)
    {
        return Task.FromResult(_estados.FirstOrDefault(e => e.Id == id));
    }

    public Task<Estado?> ObtenerPorNombreAsync(string nombre)
    {
        return Task.FromResult(_estados.FirstOrDefault(e => e.Nombre == nombre));
    }

    public Task<IEnumerable<Estado>> ObtenerTodosAsync()
    {
        return Task.FromResult<IEnumerable<Estado>>(_estados);
    }

    public Task AgregarAsync(Estado estado)
    {
        _estados.Add(estado);
        return Task.CompletedTask;
    }

    public Task ActualizarAsync(Estado estado)
    {
        var index = _estados.FindIndex(e => e.Id == estado.Id);
        if (index >= 0)
            _estados[index] = estado;

        return Task.CompletedTask;
    }
}