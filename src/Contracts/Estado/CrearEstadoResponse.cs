namespace Contracts.Estado;

public record CrearEstadoResponse(
    int Id,
    string Nombre,
    string Descripcion,
    string Estado,
    DateTime CreadoEn
);