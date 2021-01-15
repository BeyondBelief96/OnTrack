using System.Windows;
using System;
using Microsoft.Extensions.DependencyInjection;
using OnTrack.WPF.State.Navigator;
using OnTrack.WPF.ViewModels.Factory;
using OnTrack.WPF.ViewModels;

namespace OnTrack.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider =  CreateServiceProvider();
            Window window = new MainWindow();
            window.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
            window.Show();
            base.OnStartup(e);
        }

        #region Dependency Injection

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IOnTrackViewModelFactory, OnTrackViewModelFactory>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<LoanProfileViewModel>();
            services.AddSingleton<PaymentsViewModel>();
            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
            {
                return () => services.GetRequiredService<HomeViewModel>();
            });
            services.AddSingleton<CreateViewModel<LoanProfileViewModel>>(services =>
            {
                return () => services.GetRequiredService<LoanProfileViewModel>();
            });
            services.AddSingleton<CreateViewModel<PaymentsViewModel>>(services =>
            {
                return () => services.GetRequiredService<PaymentsViewModel>();
            });
            return services.BuildServiceProvider();
        }

        #endregion
    }
}
