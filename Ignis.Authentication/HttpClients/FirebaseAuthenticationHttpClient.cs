using System.Net.Http.Json;
using Ignis.Authentication.Builders;
using Ignis.Authentication.Contracts.Requests;
using Ignis.Authentication.Contracts.Responses;
using Ignis.Authentication.HttpClients.Abstractions;
using Ignis.Authentication.Models;
using Ignis.Authentication.Options;
using Microsoft.Extensions.Options;

namespace Ignis.Authentication.HttpClients;

internal sealed class FirebaseAuthenticationHttpClient : IFirebaseAuthenticationHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly FirebaseOptions _firebaseOptions;
    private readonly GoogleOAuthOptions _authOptions;

    public FirebaseAuthenticationHttpClient(HttpClient httpClient, IOptions<FirebaseOptions> firebaseOptions, IOptions<GoogleOAuthOptions> options)
    {
        _httpClient = httpClient;
        _firebaseOptions = firebaseOptions.Value;
        _authOptions = options.Value;
    }

    public async Task<EmailSignUpResponse?> SignUpAsync(EmailSignUpRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(FirebaseApiEndpoints.Authentication.SignUp(_firebaseOptions.ApiKey), request, cancellationToken);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<EmailSignUpResponse>(cancellationToken);
    }

    public async Task<EmailSignInResponse?> EmailSignInAsync(EmailSignInRequest request, CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(FirebaseApiEndpoints.Authentication.EmailSignIn(_firebaseOptions.ApiKey), request, 
                cancellationToken);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<EmailSignInResponse>(cancellationToken);
    }

    public async Task<AnonymousSignInResponse?> AnonymousSignInAsync(AnonymousSignInRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _httpClient
            .PostAsJsonAsync(FirebaseApiEndpoints.Authentication.AnonymousSignIn(_firebaseOptions.ApiKey), request,
                cancellationToken);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<AnonymousSignInResponse>(cancellationToken);
    }
    
    public Task<string> GetOAuthSignInLinkUsingGoogleAsync()
    {
        var requestUri = new OAuthUriBuilder(FirebaseApiEndpoints.Authentication.GoogleAuthUri)
            .AddDefaultQueryParameters(_authOptions)
            .AddQueryParameters(
            [
                new KeyValuePair<string, string>("scope", _authOptions.AuthScope),
                new KeyValuePair<string, string>("client_id", _authOptions.ClientId),
                new KeyValuePair<string, string>("redirect_uri", _authOptions.RedirectUri)
            ]);
        
        return Task.FromResult(requestUri.Build());
    }

    public async Task<OAuthSignInResponse?> OAuthSignInAsync(string accessToken, CancellationToken cancellationToken)
    {

        var request = new OAuthSignInRequest
        {
            RequestUri = "https://localhost",
            PostBody = $"access_token={accessToken}&providerId=google.com",
            ReturnSecureToken = true,
            ReturnIdpCredential = true
        };
        
        var response = await _httpClient.PostAsJsonAsync(
            FirebaseApiEndpoints.Authentication.FirebaseOAuthSignIn(_firebaseOptions.ApiKey), request, cancellationToken);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<OAuthSignInResponse>(cancellationToken: cancellationToken);
    }

    public async Task<GoogleAccessTokenResponse?> GetAccessTokenFromGoogleIdToken(string code,
        CancellationToken cancellationToken)
    {
        string requestUri = new OAuthUriBuilder(FirebaseApiEndpoints.Authentication.GoogleAccessCodeUri)
            .AddQueryParameters(
            [
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("client_id", _authOptions.ClientId),
                new KeyValuePair<string, string>("client_secret", _authOptions.ClientSecret),
                new KeyValuePair<string, string>("redirect_uri", _authOptions.RedirectUri),
                new KeyValuePair<string, string>("grant_type", _authOptions.GrantType),
            ]).Build();
        
        var response = await _httpClient.PostAsync(requestUri, null, cancellationToken);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<GoogleAccessTokenResponse>(cancellationToken);
    }
}