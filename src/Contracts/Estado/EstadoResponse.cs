namespace DemoV3.Contracts.Estados;

public record EstadoResponse(
    int Id,
    string Nombre,
    string Descripcion,
    string Estado,
    DateTime CreadoEn,
    DateTime? ActualizadoEn
);