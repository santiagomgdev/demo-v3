namespace DemoV3.Contracts.Common;

public class Resultado<T>
{
    public bool EsExitoso { get; }
    public T? Valor { get; }
    public Error? Error { get; }

    private Resultado(bool esExitoso, T? valor, Error? error)
    {
        EsExitoso = esExitoso;
        Valor = valor;
        Error = error;
    }

    public static Resultado<T> Exitoso(T valor) => new(true, valor, null);
    public static Resultado<T> Fallido(Error error) => new(false, default, error);
}

public class Resultado
{
    public bool EsExitoso { get; }
    public Error? Error { get; }

    private Resultado(bool esExitoso, Error? error)
    {
        EsExitoso = esExitoso;
        Error = error;
    }

    public static Resultado Exitoso() => new(true, null);
    public static Resultado Fallido(Error error) => new(false, error);
}
