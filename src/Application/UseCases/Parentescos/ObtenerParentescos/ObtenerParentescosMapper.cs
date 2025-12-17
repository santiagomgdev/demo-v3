using Contracts.Paises;
using Contracts.Parentesco;
using Domain.Entities;

namespace Application.Features.Parentescos.ObtenerParentescos;

public static class ObtenerParentescosMapper
{
    public static ParentescoResponse Mapear(Parentesco parentesco)
    {
        return new ParentescoResponse(
            parentesco.ParentescoId,
            parentesco.Codigo,
            parentesco.Descripcion,
            parentesco.Estado,
            parentesco.UsuarioCreacion,
            parentesco.FechaCreacion,
            parentesco.FechaModificacion,
            parentesco.UsuarioModificacion
            );
    }
}