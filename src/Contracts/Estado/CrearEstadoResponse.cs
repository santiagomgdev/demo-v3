namespace DemoV3.Contracts.Estados;

public record CrearEstadoResponse(
    int Id,
    string Nombre,
    string Descripcion,
    string Estado,
    DateTime CreadoEn
);