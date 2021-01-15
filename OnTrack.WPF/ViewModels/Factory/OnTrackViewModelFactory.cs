using System;

namespace OnTrack.WPF.ViewModels.Factory
{
    public class OnTrackViewModelFactory : IOnTrackViewModelFactory
    {
        #region Fields

        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<LoanProfileViewModel> _createLoanProfileViewModel;
        private readonly CreateViewModel<PaymentsViewModel> _createPaymentsViewModel;

        #endregion

        #region Constructors

        public OnTrackViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<LoanProfileViewModel> createLoanProfileViewModel,
            CreateViewModel<PaymentsViewModel> createPaymentsViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createLoanProfileViewModel = createLoanProfileViewModel;
            _createPaymentsViewModel = createPaymentsViewModel;
        }

        #endregion

        #region Methods

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.LoanProfile:
                    return _createLoanProfileViewModel();
                case ViewType.Payments:
                    return _createPaymentsViewModel();
                default:
                    throw new ArgumentException("This view type does not have a view model.");
            }
        }

        #endregion
    }
}
