using System.Text.Json.Serialization;

namespace Ignis.Authentication.Contracts.Requests;

public sealed class OAuthSignInRequest
{
    [JsonPropertyName("requestUri")]
    public required string RequestUri { get; init; }
    
    [JsonPropertyName("postBody")]
    public required string PostBody { get; init; }
    
    [JsonPropertyName("returnSecureToken")]
    public required bool ReturnSecureToken { get; init; }
    
    [JsonPropertyName("ReturnIdpCredential")]
    public required bool ReturnIdpCredential { get; init; }
}
