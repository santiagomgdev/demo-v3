using DemoV3.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoV3.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Estado> Estados => Set<Estado>();
    public DbSet<Pais> Paises => Set<Pais>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}