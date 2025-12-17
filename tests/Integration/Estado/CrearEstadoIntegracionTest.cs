using Application.Data;
using Application.Features.Estados.CrearEstado;
using Contracts.Estado;
using Domain.Repositories;

namespace Integration.Estado;

public class CrearEstadoIntegrationTest
{
    [Fact]
    public async Task CrearEstado_ConDatosValidos_DeberiaCrearEstado()
    {
        // Arrange
        IEstadoRepository repository = new InMemoryRepository();
        var handler = new CrearEstadoHandler(repository);
        var request = new CrearEstadoRequest(
            "PRUEBA",
            "Estado PRUEBA con tipo estado Normal");

        // Act
        var result = await handler.Handle(request);

        // Assert
        Assert.True(result.EsExitoso);
        Assert.NotNull(result.Valor);
        Assert.Equal("PRUEBA", result.Valor.Nombre);
        Assert.Equal("Estado PRUEBA con tipo estado Normal", result.Valor.Descripcion);
    }

    [Fact]
    public async Task CrearEstado_ConNombreDuplicado_DeberiaRetornarError()
    {
        // Arrange
        var repository = new InMemoryRepository();
        var handler = new CrearEstadoHandler(repository);
        var request = new CrearEstadoRequest("PRUEBA", "Estado PRUEBA con tipo estado Normal");

        await handler.Handle(request);

        // Act
        var result = await handler.Handle(request);

        // Assert
        Assert.False(result.EsExitoso);
        Assert.NotNull(result.Error);
        Assert.Equal("Estado.Duplicado", result.Error.Codigo);
    }
}