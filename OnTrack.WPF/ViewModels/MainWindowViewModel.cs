using OnTrack.WPF.Commands;
using OnTrack.WPF.State.Navigator;
using OnTrack.WPF.ViewModels.Factory;
using System;
using System.Windows.Input;

namespace OnTrack.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private readonly INavigator _navigator;

        #endregion

        #region Constructors

        public MainWindowViewModel(INavigator navigator, IOnTrackViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _navigator.StateChanged += Navigator_OnStateChanged;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
        }

        #endregion

        #region Properties

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; private set; }

        #endregion

        #region Event Handlers

        private void Navigator_OnStateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        #endregion
    }
}
