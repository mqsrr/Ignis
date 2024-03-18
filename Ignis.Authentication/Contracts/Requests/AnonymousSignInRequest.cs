namespace Ignis.Authentication.Contracts.Requests;

public sealed class AnonymousSignInRequest
{
    public required bool ReturnSecureToken { get; init; }
}