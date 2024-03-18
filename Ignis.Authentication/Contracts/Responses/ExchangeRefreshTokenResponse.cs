namespace Ignis.Authentication.Contracts.Responses;

public sealed class ExchangeRefreshTokenResponse
{
    public required string ExpiresIn { get; init; }

    public required string TokenType { get; init; }

    public required string RefreshToken { get; init; }

    public required string IdToken { get; init; }

    public required string UserId { get; init; }

    public required string ProjectId { get; init; }
}