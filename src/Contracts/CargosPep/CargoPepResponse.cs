namespace Contracts.CargosPep;

public record CargoPepResponse(
    int Codigo,
    string Nombre,
    bool Estado,
    string UsuarioCreacion,
    DateTime FechaCreacion,
    DateTime? FechaModificacion,
    string? UsuarioModificacion
);