using Ignis.Authentication.Contracts.Requests;
using Ignis.Authentication.Contracts.Responses;

namespace Ignis.Authentication.HttpClients.Abstractions;

public interface IFirebaseAuthenticationHttpClient
{
    public Task<EmailSignUpResponse?> SignUpAsync(EmailSignUpRequest request);

    public Task<EmailSignInResponse?> EmailSignInAsync(EmailSignInRequest request);

    public Task<AnonymousSignInResponse?> AnonymousSignInAsync(AnonymousSignInRequest request);

    public Task<OAuthSignInResponse?> OAuthSignInAsync(OAuthSignInRequest request);
}