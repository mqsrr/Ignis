namespace Ignis.Authentication.Contracts.Responses;

public sealed class AnonymousSignInResponse
{
    public required string IdToken { get; init; }

    public required string RefreshToken { get; init; }

    public required string ExpiresIn { get; init; }

    public required string LocalId { get; init; }
}