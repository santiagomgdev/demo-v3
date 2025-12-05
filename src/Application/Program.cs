using DemoV3.Application.Common.Middleware;
using DemoV3.Application.Estados.UseCases.CrearEstado;
using DemoV3.Domain.Services;
using DemoV3.Infrastructure;
using DemoV3.Infrastructure.Data.Seeders;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<EstadoService>();

builder.Services.AddScoped<CrearEstadoHandler>();

builder.Services.AddScoped<CrearEstadoValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    await seeder.SeedAsync();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapCrearEstado();

app.Run();