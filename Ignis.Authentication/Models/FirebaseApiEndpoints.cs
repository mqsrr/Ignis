namespace Ignis.Authentication.Models;

internal static class FirebaseApiEndpoints
{
    internal static class Authentication
    {
        internal static string SignUp(string apiKey) =>
            $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={apiKey}";

        internal static string EmailSignIn(string apiKey) =>
            $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={apiKey}";

        internal static string AnonymousSignIn(string apiKey) =>
            $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={apiKey}";

        internal static string FirebaseOAuthSignIn(string apiKey) =>
            $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={apiKey}";

        internal const string GoogleAuthUri = "https://accounts.google.com/o/oauth2/v2/auth";

        internal const string GoogleAccessCodeUri = "https://oauth2.googleapis.com/token";

    }
}