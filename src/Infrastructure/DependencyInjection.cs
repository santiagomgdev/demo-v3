using DemoV3.Infrastructure.Data.Seeders;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // PG Database Context
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));

        // Repositorios
        services.AddScoped<IEstadoRepository, EstadoRepository>();
        services.AddScoped<IPaisRepository, PaisRepository>();
        services.AddScoped<IParentescoRepository, ParentescoRepository>();

        services.AddScoped<ISeeder, EstadoSeeder>();
        services.AddScoped<ISeeder, ParentescoSeeder>();
        services.AddScoped<DatabaseSeeder>();

        return services;
    }
}