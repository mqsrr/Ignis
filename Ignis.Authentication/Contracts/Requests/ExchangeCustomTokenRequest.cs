namespace Ignis.Authentication.Contracts.Requests;

public sealed class ExchangeCustomTokenRequest
{
    public required string Token { get; init; }
    
    public required bool ReturnSecureToken { get; init; }
}