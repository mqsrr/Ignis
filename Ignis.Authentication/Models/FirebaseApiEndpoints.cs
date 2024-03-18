namespace Ignis.Authentication.Models;

public static class FirebaseApiEndpoints
{
    internal static class Authentication
    {
        internal static string SignUp(string apiKey) =>
            $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={apiKey}";

        internal static string EmailSignIn(string apiKey) =>
            $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={apiKey}";

        internal static string AnonymousSignIn(string apiKey) =>
            $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={apiKey}";

        internal static string OAuthSignIn(string apiKey) =>
            $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={apiKey}";
    }
}