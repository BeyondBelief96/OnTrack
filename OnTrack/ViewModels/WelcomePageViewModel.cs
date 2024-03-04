using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OnTrack.Services;

namespace OnTrack.ViewModels;

public partial class WelcomePageViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    public WelcomePageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    [RelayCommand]
    public void NavigateToLogin()
    {
        _navigationService.NavigateTo<LoginViewModel>();
    }
}
