namespace DemoV3.Contracts.Common;

public record Error(string Codigo, string Mensaje)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "El valor requerido es nulo");
}