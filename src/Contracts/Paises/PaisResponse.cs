namespace Contracts.Paises;

public record PaisResponse(
    string Codigo,
    string Nombre,
    bool Estado,
    string UsuarioCreacion,
    DateTime FechaCreacion,
    DateTime? FechaModificacion,
    string? UsuarioModificacion
);