using CommunityToolkit.Mvvm.ComponentModel;
using OnTrack.Factory;
using OnTrack.ViewModels;

namespace OnTrack.Services;

public partial class NavigationService : INavigationService
{

    public event Action? CurrentViewModelChanged;

    private BaseViewModel? _currentViewModel;
    private readonly Func<Type, BaseViewModel> _viewModelFactory;

    public NavigationService(Func<Type, BaseViewModel> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public BaseViewModel? CurrentViewModel
    {
        get { return _currentViewModel; }
        private set
        {
            if(_currentViewModel != value)
            {
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }
    }

    public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
    {
        var viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentViewModel = viewModel;
    }
}
