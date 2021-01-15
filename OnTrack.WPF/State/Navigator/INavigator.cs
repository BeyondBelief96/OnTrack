using OnTrack.WPF.ViewModels;
using System;

namespace OnTrack.WPF.State.Navigator
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        event Action StateChanged;
    }
}
