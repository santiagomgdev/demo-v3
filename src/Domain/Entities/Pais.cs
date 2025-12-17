
namespace DemoV3.Domain.Entities;

public class Pais()
{
    public string Codigo { get; private set; } = string.Empty;
    public string Nombre { get; private set; } = string.Empty;
    public bool Estado { get; private set; } = true;
    public string UsuarioCreacion { get; private set; } = string.Empty;
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaModificacion { get; private set; }
    public string? UsuarioModificacion { get; private set; } = string.Empty;

    public static Pais Crear(string codigo, string nombre, string usuarioCreacion)
    {
        return new Pais
        {
            Codigo = codigo,
            Nombre = nombre,
            UsuarioCreacion = usuarioCreacion,
            FechaCreacion = DateTime.UtcNow
        };
    }
}


