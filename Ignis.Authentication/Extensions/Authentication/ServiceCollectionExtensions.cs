using Ignis.Authentication.HttpClients;
using Ignis.Authentication.HttpClients.Abstractions;
using Ignis.Authentication.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ignis.Authentication.Extensions.Authentication;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFirebaseAuthenticationHttpClient(this IServiceCollection serviceCollection, string apiKey, Action<GoogleOAuthOptions>? options = null)
    {
        serviceCollection.AddHttpClient<IFirebaseAuthenticationHttpClient, FirebaseAuthenticationHttpClient>((_, client) =>
            client.BaseAddress = new Uri("https://identitytoolkit.googleapis.com/v1/accounts"));

        
        if (options is not null)
        {
            var googleOAuthOptions = new GoogleOAuthOptions
            {
                ClientId = null!,
                ClientSecret = null!,
                RedirectUri = null!,
            };

            options.Invoke(googleOAuthOptions);
            serviceCollection.AddTransient<IOptions<GoogleOAuthOptions>>(_ => Microsoft.Extensions.Options.Options.Create(googleOAuthOptions));
        }
        
        serviceCollection.AddTransient<IOptions<FirebaseOptions>>(_ => Microsoft.Extensions.Options.Options.Create(
            new FirebaseOptions
            {
                ApiKey = apiKey
            }));
        
        return serviceCollection;
    }
}