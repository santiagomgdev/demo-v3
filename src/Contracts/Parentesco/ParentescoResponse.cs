using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Parentesco
{
    public record ParentescoResponse(
            int ParentescoId,
            string Codigo,
            string Descripcion,
            bool Estado,
            string UsuarioCreacion,
            DateTime FechaCreacion,
            DateTime? FechaModificacion,
            string? UsuarioModificacion
        );
}
