using System.Text.Json.Serialization;

namespace Ignis.Authentication.Contracts.Responses;

public sealed class GoogleAccessTokenResponse
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
    
    [JsonPropertyName("expires_in")]
    public required int ExpiresIn { get; init; }

    [JsonPropertyName("scope")]
    public required string Scope { get; init; }

    [JsonPropertyName("token_type")]
    public required string TokenType { get; init; }

    [JsonPropertyName("refresh_token")] 
    public string RefreshToken { get; init; } = null!;
}