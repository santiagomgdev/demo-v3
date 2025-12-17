using Domain.Entities;
using Domain.Enums;

namespace Domain.Services;

public class EstadoService
{
    public bool PuedeProcesar(Estado estado)
    {
        if (estado is null) return false;

        if (estado.TipoEstado == TipoEstado.Cancelado) return false;

        return true;
    }

    public ResultadoProceso ProcesarEstado(Estado estado)
    {
        ArgumentNullException.ThrowIfNull(estado);
        
        if (!PuedeProcesar(estado)) throw new InvalidOperationException("Estado no puede ser procesado");

        var procesadoEn = DateTime.UtcNow;

        return new ResultadoProceso(
            EstadoId: estado.Id,
            ProcesadoEn: procesadoEn,
            Success: true 
        );
    }
}

public record ResultadoProceso(
    int EstadoId,
    DateTime ProcesadoEn,
    bool Success
);