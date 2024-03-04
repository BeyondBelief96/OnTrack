using Firebase.Auth;
using Firebase.Auth.UI;
using OnTrack.ViewModels;
using System.Windows;

namespace OnTrack.Services;

public class AuthenticationService : IAuthenticationService
{
    public event Action? OnUserLoggedIn;
    public event Action? OnUserLoggedOut;

    private readonly INavigationService _navigationService;

    public AuthenticationService(INavigationService navigationService)
    {
        _navigationService = navigationService;
        FirebaseUI.Instance.Client.AuthStateChanged += Client_AuthStateChanged;
    }

    public User? LoggedInUser { get; set; }

    public bool UserLoggedIn => LoggedInUser == null ? false : true;

    private void Client_AuthStateChanged(object? sender, Firebase.Auth.UserEventArgs e)
    {
        Application.Current.Dispatcher.Invoke(() =>
        {
            if (e.User == null)
            {
                if(LoggedInUser != null)
                {
                    LoggedInUser = null;
                    OnUserLoggedOut?.Invoke();
                    _navigationService.NavigateTo<WelcomePageViewModel>();
                }

            }
            else
            {
                LoggedInUser = e.User;
                OnUserLoggedIn?.Invoke();
                _navigationService.NavigateTo<HomePageViewModel>();
            }
        });
    }
}
