using Ignis.Authentication.HttpClients.Abstractions;

namespace Ignis.Authentication.HttpClients;

internal sealed class FirebaseHttpClient : IFirebaseHttpClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FirebaseHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
}