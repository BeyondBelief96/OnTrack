using OnTrack.WPF.State.Navigator;
using OnTrack.WPF.ViewModels.Factory;
using System;
using System.Windows.Input;

namespace OnTrack.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Fields

        private readonly INavigator _navigator;
        private readonly IOnTrackViewModelFactory _viewModelFactory;

        #endregion

        #region Constructors

        public UpdateCurrentViewModelCommand(INavigator navigator, IOnTrackViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        #endregion

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                var viewModelType = (ViewType) parameter;
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewModelType);
            }
            
        }
    }
}
