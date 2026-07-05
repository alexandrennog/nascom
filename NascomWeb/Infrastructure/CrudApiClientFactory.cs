namespace NascomWeb.Infrastructure;

public class CrudApiClientFactory
{
    public const string HttpClientName = "NascomApi";

    private readonly IHttpClientFactory _httpClientFactory;

    public CrudApiClientFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public CrudApiClient<TDto> Create<TDto>(string recurso) where TDto : class
        => new(_httpClientFactory.CreateClient(HttpClientName), recurso);
}
