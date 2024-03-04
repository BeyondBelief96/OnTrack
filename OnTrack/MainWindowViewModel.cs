using CommunityToolkit.Mvvm.Input;
using Firebase.Auth.UI;
using OnTrack.Services;
using OnTrack.ViewModels;

namespace OnTrack;

public partial class MainWindowViewModel : BaseViewModel
{
    private INavigationService _navigationService;
    private readonly IAuthenticationService _authenticationService;

    public MainWindowViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
    {
        _navigationService = navigationService;
        _authenticationService = authenticationService;
        _authenticationService.OnUserLoggedIn += _authenticationService_OnUserLoggedIn;
        _navigationService.CurrentViewModelChanged += _navigationService_CurrentViewModelChanged;
        _navigationService.NavigateTo<WelcomePageViewModel>();
    }


    public BaseViewModel? CurrentViewModel => _navigationService.CurrentViewModel;

    public bool UserLoggedIn => _authenticationService.UserLoggedIn;

    [RelayCommand]
    public void SignOut()
    {
        FirebaseUI.Instance.Client.SignOut();
    }

    private void _navigationService_CurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }


    private void _authenticationService_OnUserLoggedIn()
    {
        OnPropertyChanged(nameof(UserLoggedIn));
    }
}
