namespace Ignis.Authentication.Contracts.Responses;

public sealed class OAuthSignInResponse
{
    public required string FederatedId { get; init; }
    
    public required string ProviderId { get; init; }
    
    public required string LocalId { get; init; }
    
    public required bool EmailVerified { get; init; }
    
    public required string Email { get; init; }
    
    public string OAuthIdToken { get; init; }
    
    public required string OAuthAccessToken { get; init; }
    
    public string OAuthTokenSecret { get; init; }
    
    public required string RawUserInfo { get; init; }
    
    public required string FirstName { get; init; }
    
    public required string LastName { get; init; }
    
    public required string FullName { get; init; }
    
    public required string DisplayName { get; init; }
    
    public required string PhotoUrl { get; init; }
    
    public required string IdToken { get; init; }
    
    public required string RefreshToken { get; init; }
    
    public required string ExpiresIn { get; init; }
    
    public bool NeedConfirmation { get; init; }
}
