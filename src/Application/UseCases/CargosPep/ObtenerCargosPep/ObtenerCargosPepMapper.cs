using Contracts.CargosPep;
using Contracts.Paises;
using Contracts.Parentesco;
using Domain.Entities;

namespace Application.UseCases.Parentescos.ObtenerParentescos;

public static class ObtenerCargosPepMapper
{
    public static CargoPepResponse Mapear(CargoPep cargoPep)
    {
        return new CargoPepResponse(
            cargoPep.Codigo,
            cargoPep.Nombre,
            cargoPep.Estado,
            cargoPep.UsuarioCreacion,
            cargoPep.FechaCreacion,
            cargoPep.FechaModificacion,
            cargoPep.UsuarioModificacion
            );
    }
}