using DemoV3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoV3.Infrastructure.Data.Seeders;

public class EstadoSeeder(ApplicationDbContext context) : ISeeder
{
    private readonly ApplicationDbContext _context = context;

    public int Order => 1;

    public async Task SeedAsync()
    {
        if (await _context.Estados.AnyAsync()) return;

        Estado[] estados = [
            Estado.Crear(
                "EN REGISTRO", "Estado EN REGISTRO con tipo estado Normal"),
            Estado.Crear(
                "APROBADA", "Estado APROBADA con tipo estado Normal"),
            Estado.Crear(
                "NEGADA", "Estado NEGADA con tipo estado Normal"),
            Estado.Crear(
                "DESISTIDA", "Estado DESISTIDA con tipo estado Normal"),
            Estado.Crear(
                "CADUCADA", "Estado CADUCADA con tipo estado Normal"),
        ];

        await _context.Estados.AddRangeAsync(estados);
        await _context.SaveChangesAsync();
    }
}