namespace Ignis.Authentication.Contracts.Requests;

public sealed class EmailSignUpRequest
{
    public required string Email { get; init; }

    public required string Password { get; init; }
    
    public required bool ReturnSecureToken { get; init; }
}