using DemoV3.Infrastructure.Data.Seeders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Seeders;

public class ParentescoSeeder(ApplicationDbContext context) : ISeeder
{
    private readonly ApplicationDbContext _context = context;

    public int Order => 2;

    public async Task SeedAsync()
    {
        if (await _context.Parentescos.AnyAsync()) return;

        Parentesco[] parentescos = [
            Parentesco.Crear("00", "NINGUNO", "MIGRACION"),
            Parentesco.Crear("01", "ABUELO", "MIGRACION"),
            Parentesco.Crear("02", "CONYUGE", "MIGRACION"),
            Parentesco.Crear("03", "CUÑADO", "MIGRACION"),
            Parentesco.Crear("04", "ENTIDAD VINCULADA", "MIGRACION"),
            Parentesco.Crear("05", "HERMANOS", "MIGRACION"),
            Parentesco.Crear("06", "HIJO ADOPTIVO", "MIGRACION"),
            Parentesco.Crear("07", "HIJO", "MIGRACION"),
            Parentesco.Crear("08", "MADRE ADOPTANTE", "MIGRACION"),
            Parentesco.Crear("09", "MADRE", "MIGRACION"),
            Parentesco.Crear("10", "NIETO", "MIGRACION"),
            Parentesco.Crear("11", "PADRE ADOPTANTE", "MIGRACION"),
            Parentesco.Crear("12", "PADRE", "MIGRACION"),
            Parentesco.Crear("13", "COMPAÑERO PERM.", "MIGRACION"),
            Parentesco.Crear("14", "PRIMOS", "MIGRACION"),
            Parentesco.Crear("15", "SOBRINO", "MIGRACION"),
            Parentesco.Crear("16", "SUEGRA", "MIGRACION"),
            Parentesco.Crear("17", "TIO", "MIGRACION"),
            Parentesco.Crear("18", "YERNO", "MIGRACION"),
            Parentesco.Crear("19", "NUERA", "MIGRACION"),
            Parentesco.Crear("20", "BISABUELO(A)", "MIGRACION"),
            Parentesco.Crear("21", "BISNIETO(A)", "MIGRACION"),
            Parentesco.Crear("22", "PRIMO(A) HERMANO(A)", "MIGRACION"),
            Parentesco.Crear("23", "TIO(A) ABUELO(A)", "MIGRACION")
        ];

        await _context.Parentescos.AddRangeAsync(parentescos);
        await _context.SaveChangesAsync();
    }
}
