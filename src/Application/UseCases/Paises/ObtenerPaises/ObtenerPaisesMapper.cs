using Contracts.Paises;
using Domain.Entities;

namespace Application.UseCases.Paises.ObtenerPaises;

public static class ObtenerPaisesMapper
{
    public static PaisResponse Mapear(Pais pais)
    {
        return new PaisResponse(
            pais.Codigo,
            pais.Nombre,
            pais.Estado,
            pais.UsuarioCreacion,
            pais.FechaCreacion,
            pais.FechaModificacion,
            pais.UsuarioModificacion
            );
    }
}