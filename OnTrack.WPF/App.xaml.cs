using System.Windows;
using System;
using Microsoft.Extensions.DependencyInjection;

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
            base.OnStartup(e);
        }

        #region Dependency Injection

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            return services.BuildServiceProvider();
        }

        #endregion
    }
}
