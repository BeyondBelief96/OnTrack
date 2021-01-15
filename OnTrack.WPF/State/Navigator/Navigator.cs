using OnTrack.WPF.ViewModels;
using System;

namespace OnTrack.WPF.State.Navigator
{
    public class Navigator : INavigator
    {
        #region Events

        public event Action StateChanged;

        #endregion

        #region Fields

        private ViewModelBase _currentViewModel;

        #endregion

        #region Constructors

        public Navigator()
        {

        }

        #endregion

        #region Properties

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        #endregion

        
    }
}
