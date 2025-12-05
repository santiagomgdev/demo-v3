namespace DemoV3.Infrastructure.Data.Seeders;

public interface ISeeder
{
    Task SeedAsync();
    int Order { get; }
}