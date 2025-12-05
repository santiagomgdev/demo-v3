using DemoV3.Contracts.Interfaces;
using DemoV3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoV3.Infrastructure.Data.Repositories;

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

    public async Task<IEnumerable<Estado>> ObtenerTodosAsync()
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