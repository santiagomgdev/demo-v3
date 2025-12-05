using Microsoft.Extensions.DependencyInjection;

namespace DemoV3.Infrastructure.Data.Seeders;

public class DatabaseSeeder(IServiceProvider serviceProvider)
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task SeedAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var seeders = scope.ServiceProvider
            .GetServices<ISeeder>()
            .OrderBy(s => s.Order)
            .ToList();

        if (seeders.Count == 0) return;

        foreach (var seeder in seeders)
        {
            var seederName = seeder.GetType().Name;
            await seeder.SeedAsync();
        }
    }
}