using Firebase.Auth;

namespace OnTrack.Services
{
    public interface IAuthenticationService
    {
        event Action? OnUserLoggedIn;

        event Action? OnUserLoggedOut;
        bool UserLoggedIn { get; }
        User? LoggedInUser { get; set; }
    }
}