using DemoV3.Domain.Enums;
using DemoV3.Domain.ValueObjects;

namespace DemoV3.Domain.Entities;

public class Estado
{
    public int Id { get; private set; }
    public TipoEstado TipoEstado { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public Descripcion Descripcion { get; private set; } = null!;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    private Estado() { }

    public static Estado Crear(string nombre, string descripcion)
    {
        if (string.IsNullOrWhiteSpace(descripcion))
            throw new EstadoInvalidoException("Descripción es requerida");
        
        return new Estado
        {
            Nombre = nombre,
            TipoEstado = TipoEstado.Normal,
            Descripcion = Descripcion.Crear(descripcion),
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Actualizar(string nombre, string descripcion)
    {
        if (TipoEstado == TipoEstado.Cancelado)
            throw new EstadoInvalidoException("No se puede actualizar el estado cancelado");

        Nombre = nombre;
        Descripcion = Descripcion.Crear(descripcion);
        UpdatedAt = DateTime.UtcNow;
    }

    public void Desactivar()
    {
        if (TipoEstado == TipoEstado.Denegado)
            throw new EstadoInvalidoException("Estado ya está cancelado");

        TipoEstado = TipoEstado.Denegado;
        UpdatedAt = DateTime.UtcNow;
    }

    public class EstadoInvalidoException(string message) : Exception(message) { }
}