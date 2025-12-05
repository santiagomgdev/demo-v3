namespace DemoV3.Domain.ValueObjects;

public sealed record Descripcion
{
    public string Valor { get; } = string.Empty;

    private Descripcion(string valor)
    {
        Valor = valor;
    }

    public static Descripcion Crear(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor)) 
            throw new ArgumentException("Descripcion no puede ser vacio", nameof(valor));

        if (valor.Length < 10 || valor.Length > 50) 
            throw new ArgumentException("Descripción debe contener entre 10 y 50 carácteres", nameof(valor));

        return new Descripcion(valor);
    }

    public override string ToString() => Valor; 
}