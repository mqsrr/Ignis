namespace Ignis.Authentication.Contracts.Responses;

public sealed class EmailSignInResponse
{
    public required string IdToken { get; init; }
    
    public required string Email { get; init; }
    
    public required string RefreshToken { get; init; }
    
    public required string ExpiresIn { get; init; }

    public required string LocalId { get; init; }

    public required bool Registered { get; init; }
}