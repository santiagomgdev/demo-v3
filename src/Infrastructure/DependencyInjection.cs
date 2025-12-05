using DemoV3.Contracts.Interfaces;
using DemoV3.Infrastructure.Data;
using DemoV3.Infrastructure.Data.Repositories;
using DemoV3.Infrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoV3.Infrastructure;

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

        services.AddScoped<ISeeder, EstadoSeeder>();
        services.AddScoped<DatabaseSeeder>();

        return services;
    }
}