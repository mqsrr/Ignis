using System.Net.Http.Json;
using Ignis.Authentication.Contracts.Requests;
using Ignis.Authentication.Contracts.Responses;
using Ignis.Authentication.HttpClients.Abstractions;
using Ignis.Authentication.Models;
using Ignis.Authentication.Options;

namespace Ignis.Authentication.HttpClients;

internal sealed class FirebaseAuthenticationHttpClient : IFirebaseAuthenticationHttpClient
{
    private readonly HttpClient _httpClient;
    private readonly FirebaseOptions _firebaseOptions;

    public FirebaseAuthenticationHttpClient(HttpClient httpClient, FirebaseOptions firebaseOptions)
    {
        _httpClient = httpClient;
        _firebaseOptions = firebaseOptions;
    }

    public async Task<EmailSignUpResponse?> SignUpAsync(EmailSignUpRequest request)
    {
        var response = await _httpClient
            .PostAsJsonAsync(FirebaseApiEndpoints.Authentication.SignUp(_firebaseOptions.ApiKey), request);
        
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<EmailSignUpResponse>();
    }

    public async Task<EmailSignInResponse?> EmailSignInAsync(EmailSignInRequest request)
    {
        var response = await _httpClient
            .PostAsJsonAsync(FirebaseApiEndpoints.Authentication.EmailSignIn(_firebaseOptions.ApiKey), request);
      
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<EmailSignInResponse>();
    }

    public async Task<AnonymousSignInResponse?> AnonymousSignInAsync(AnonymousSignInRequest request)
    {
        var response = await _httpClient
            .PostAsJsonAsync(FirebaseApiEndpoints.Authentication.AnonymousSignIn(_firebaseOptions.ApiKey), request);
        
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<AnonymousSignInResponse>();
    }

    public async Task<OAuthSignInResponse?> OAuthSignInAsync(OAuthSignInRequest request)
    {
        var response = await _httpClient
            .PostAsJsonAsync(FirebaseApiEndpoints.Authentication.OAuthSignIn(_firebaseOptions.ApiKey), request);
        
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<OAuthSignInResponse>();
    }
}