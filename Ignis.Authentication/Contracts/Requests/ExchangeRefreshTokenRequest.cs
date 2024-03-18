namespace Ignis.Authentication.Contracts.Requests;

public sealed class ExchangeRefreshTokenRequest
{
    public required string GrantType { get; init; }
    
    public required string RefreshToken { get; init; }
}