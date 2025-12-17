using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class PaisRepository(ApplicationDbContext context) : IPaisRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Pais?> ObtenerPorIdAsync(int id)
    {
        return await _context.Paises.FindAsync(id);
    }

    public async Task<Pais?> ObtenerPorNombreAsync(string nombre)
    {
        return await _context.Paises.FirstOrDefaultAsync(e => e.Nombre == nombre);
    }

    public async Task<IEnumerable<Pais>> ObtenerTodosAsync()
    {
        return await _context.Paises.ToListAsync();
    }

    public async Task AgregarAsync(Pais pais)
    {
        await _context.Paises.AddAsync(pais);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Pais estado)
    {
        _context.Paises.Update(estado);
        await _context.SaveChangesAsync();
    }
}