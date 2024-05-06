namespace Ignis.Authentication.Options;

public sealed class GoogleOAuthOptions
{
    public required string ClientId { get; set; }

    public required string ClientSecret { get; set; }

    public required string RedirectUri { get; set; }

    public string AuthScope { get; init; } = "https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email";

    public string AccessType { get; init; } = "offline";

    public string IncludeGrantedScopes { get; init; }  = "true";

    public string ResponseType { get; init; } = "code";

    public string GrantType { get; init; } = "authorization_code";

    public string State { get; init; } = "state_parameter_passthrough_value";
}