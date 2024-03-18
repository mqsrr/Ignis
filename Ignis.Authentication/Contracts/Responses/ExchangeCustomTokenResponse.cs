namespace Ignis.Authentication.Contracts.Responses;

public sealed class ExchangeCustomTokenResponse
{
    public required string IdToken { get; init; }
    
    public required string RefreshToken { get; init; }
    
    public required string ExpiresIn { get; init; }
}