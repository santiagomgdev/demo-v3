using Domain.Entities;
using Domain.Enums;

namespace Unit.Domain.Services;

public class EstadoTests
{
    [Fact]
    public void Crear_ConDatosValidos_DeberiaCrearEstadoActivo()
    {
        // Act
        var estado = Estado.Crear("PRUEBA", "Estado PRUEBA con tipo estado Normal");

        // Assert
        Assert.Equal("PRUEBA", estado.Nombre);
        Assert.Equal("Estado PRUEBA con tipo estado Normal", estado.Descripcion.Valor);
        Assert.Equal(TipoEstado.Normal, estado.TipoEstado);
    }

    [Fact]
    public void Desactivar_EstadoActivo_DeberiaDesactivarEstado()
    {
        // Arrange
        var estado = Estado.Crear("PRUEBA", "Estado PRUEBA con tipo estado Normal");

        // Act
        estado.Desactivar();

        // Assert
        Assert.Equal(TipoEstado.Denegado, estado.TipoEstado);
        Assert.NotNull(estado.UpdatedAt);
    }

    [Fact]
    public void Desactivar_EstadoDesactivado_DeberiaArrojarExcepcion()
    {
        // Arrange
        var estado = Estado.Crear("PRUEBA", "Estado PRUEBA con tipo estado Normal");
        estado.Desactivar();

        // Act & Assert
        Assert.Throws<Estado.EstadoInvalidoException>(() => estado.Desactivar());
    }
}