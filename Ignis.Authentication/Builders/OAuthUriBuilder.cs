using System.Text;
using Ignis.Authentication.Options;

namespace Ignis.Authentication.Builders;

internal sealed class OAuthUriBuilder
{
    private readonly StringBuilder _stringBuilder;

    public OAuthUriBuilder(string baseUri)
    {
        _stringBuilder = new StringBuilder();
        
        _stringBuilder.Append(baseUri);
        _stringBuilder.Append('?');
    }

    public OAuthUriBuilder AddQueryParameter(KeyValuePair<string, string> query)
    {
        _stringBuilder.AppendFormat("{0}={1}", query.Key, query.Value);
        _stringBuilder.Append('&');
        return this;
    }
    
    public OAuthUriBuilder AddQueryParameters(IEnumerable<KeyValuePair<string,string>> queries)
    {
        foreach (var keyValuePair in queries)
        {
            AddQueryParameter(keyValuePair);
        }

        return this;
    }
    
    public OAuthUriBuilder AddDefaultQueryParameters(GoogleOAuthOptions options)
    {
        _stringBuilder.AppendFormat("access_type={0}&", options.AccessType);
        _stringBuilder.AppendFormat("include_granted_scopes={0}&", options.IncludeGrantedScopes);
        _stringBuilder.AppendFormat("response_type={0}&", options.ResponseType);
        _stringBuilder.AppendFormat("state={0}&", options.State);
        
        return this;
    }

    public string Build()
    {
        _stringBuilder.Remove(_stringBuilder.Length - 1, 1);
        return _stringBuilder.ToString();
    }
}