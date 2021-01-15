namespace OnTrack.WPF.ViewModels.Factory
{
    public enum ViewType
    {
        Home,
        LoanProfile,
        Payments
    }

    public interface IOnTrackViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
