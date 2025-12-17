using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities;

public class Parentesco
{
    public int ParentescoId { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public bool Estado { get; set; }
    public string UsuarioCreacion { get; private set; } = string.Empty;
    public DateTime FechaCreacion { get; private set; }
    public DateTime? FechaModificacion { get; private set; }
    public string? UsuarioModificacion { get; private set; } = string.Empty;

    public static Parentesco Crear(string codigo, string descripcion, string usuarioCreacion)
    {
        return new Parentesco
        {
            Codigo = codigo,
            Descripcion = descripcion,
            Estado = true,
            UsuarioCreacion = usuarioCreacion,
            FechaCreacion = DateTime.UtcNow
        };
    }

}