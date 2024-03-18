namespace Ignis.Authentication.Contracts.Requests;

public sealed class EmailSignInRequest
{
    public required string Email { get; init; }

    public required string Password { get; init; }
    
    public required bool ReturnSecureToken { get; init; }
}