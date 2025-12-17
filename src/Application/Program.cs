using Application.Common.Middleware;
using Application.Features.Estados.CrearEstado;
using Application.Features.Estados.ObtenerEstados;
using Application.UseCases.Estados.CrearEstado;
using Application.UseCases.Estados.ObtenerEstado;
using Domain.Services;
using Infrastructure;
using Infrastructure.Data.Seeders;
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

builder.Services.AddScoped<ObtenerEstadoService>();
builder.Services.AddScoped<ObtenerEstadosService>();

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
app.MapObtenerEstado();
app.MapObtenerEstados();

app.Run();