using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth.UI;
using OnTrack.Services;
using System.Windows;

namespace OnTrack.ViewModels;

public class LoginViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    public LoginViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
    }
}
