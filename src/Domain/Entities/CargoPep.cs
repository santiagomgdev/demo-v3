namespace Domain.Entities;

public class CargoPep
{
    public int Codigo { get; private set; }
    public string Nombre { get; private set; } = string.Empty;
    public bool Estado { get; private set; } = true;
    public string UsuarioCreacion { get; private set; } = string.Empty;
    public DateTime FechaCreacion { get; private set; }
    public string? UsuarioModificacion { get; private set; }
    public DateTime? FechaModificacion { get; private set; }

    private CargoPep() { }

    public static CargoPep Crear(string nombre, string usuarioCreacion)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new Exception("Nombre es requerido");

        if (nombre.Length > 200)
            throw new Exception("Nombre no puede exceder 200 caracteres");

        return new CargoPep
        {
            Nombre = nombre,
            Estado = true,
            UsuarioCreacion = usuarioCreacion,
            FechaCreacion = DateTime.UtcNow
        };
    }
}

