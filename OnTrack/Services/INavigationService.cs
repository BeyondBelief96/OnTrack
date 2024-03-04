using CommunityToolkit.Mvvm.ComponentModel;
using OnTrack.ViewModels;

namespace OnTrack.Services
{
    public interface INavigationService
    {
        event Action? CurrentViewModelChanged;

        BaseViewModel? CurrentViewModel { get; }

        void NavigateTo<TViewModel>() where TViewModel : BaseViewModel;
    }
}