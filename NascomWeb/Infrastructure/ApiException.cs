namespace NascomWeb.Infrastructure;

/// <summary>
/// Erro de negócio retornado pela API (400), com a mensagem já pronta para exibir ao usuário.
/// </summary>
public class ApiException : Exception
{
    public ApiException(string message) : base(message) { }
}
