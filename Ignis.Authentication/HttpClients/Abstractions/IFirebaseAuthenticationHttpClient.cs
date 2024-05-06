using Ignis.Authentication.Contracts.Requests;
using Ignis.Authentication.Contracts.Responses;

namespace Ignis.Authentication.HttpClients.Abstractions;

public interface IFirebaseAuthenticationHttpClient
{
    public Task<EmailSignUpResponse?> SignUpAsync(EmailSignUpRequest request, CancellationToken cancellationToken);

    public Task<EmailSignInResponse?> EmailSignInAsync(EmailSignInRequest request, CancellationToken cancellationToken);

    public Task<AnonymousSignInResponse?> AnonymousSignInAsync(AnonymousSignInRequest request, CancellationToken cancellationToken);

    public Task<string> GetOAuthSignInLinkUsingGoogleAsync();
    
    public Task<OAuthSignInResponse?> OAuthSignInAsync(string accessToken, CancellationToken cancellationToken);
    
    public Task<GoogleAccessTokenResponse?> GetAccessTokenFromGoogleIdToken(string code, CancellationToken cancellationToken);
}