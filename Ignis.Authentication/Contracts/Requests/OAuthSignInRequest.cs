namespace Ignis.Authentication.Contracts.Requests;

public sealed class OAuthSignInRequest
{
    public required string RequestUri { get; init; }
    
    public required string PostBody { get; init; }
    
    public required bool ReturnSecureToken { get; init; }
    
    public required bool ReturnIdpCredential { get; init; }
}
