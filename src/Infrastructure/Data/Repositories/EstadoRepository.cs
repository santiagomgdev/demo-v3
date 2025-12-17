using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class EstadoRepository(ApplicationDbContext context) : IEstadoRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Estado?> ObtenerPorIdAsync(int id)
    {
        return await _context.Estados.FindAsync(id);
    }

    public async Task<Estado?> ObtenerPorNombreAsync(string nombre)
    {
        return await _context.Estados.FirstOrDefaultAsync(e => e.Nombre == nombre);
    }

    public async Task<List<Estado>> ObtenerTodosAsync()
    {
        return await _context.Estados.ToListAsync();
    }

    public async Task AgregarAsync(Estado estado)
    {
        await _context.Estados.AddAsync(estado);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Estado estado)
    {
        _context.Estados.Update(estado);
        await _context.SaveChangesAsync();
    }
}