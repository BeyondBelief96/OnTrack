using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnTrack.Factory;
using OnTrack.Services;
using OnTrack.ViewModels;
using System.Windows;

namespace OnTrack;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                string? firebaseApiKey = hostContext.Configuration.GetValue<string>("FIREBASE_API_KEY");

                if (firebaseApiKey == null)
                    throw new NullReferenceException("Could not find Firebase API key in appsettings.json.");

                FirebaseUI.Initialize(new FirebaseUIConfig
                {
                    ApiKey = firebaseApiKey,
                    AuthDomain = "ontrack-7c5a3.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                    {
                        new GoogleProvider(),
                        new EmailProvider()
                    },
                    PrivacyPolicyUrl = "https://github.com/step-up-labs/firebase-authentication-dotnet",
                    TermsOfServiceUrl = "https://github.com/step-up-labs/firebase-database-dotnet",
                    IsAnonymousAllowed = false,
                    AutoUpgradeAnonymousUsers = true,
                    UserRepository = new FileUserRepository("FirebaseSample"),
                    // Func called when upgrade of anonymous user fails because the user already exists
                    // You should grab any data created under your anonymous user, sign in with the pending credential
                    // and copy the existing data to the new user
                    // see details here: https://github.com/firebase/firebaseui-web#upgrading-anonymous-users
                    AnonymousUpgradeConflict = conflict => conflict.SignInWithPendingCredentialAsync(true)
                });

                services.AddServiceFactory<LoginViewModel>();
                services.AddServiceFactory<HomePageViewModel>();
                services.AddServiceFactory<WelcomePageViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainWindowViewModel>();
                services.AddSingleton<INavigationService, NavigationService>();
                services.AddSingleton<IAuthenticationService, AuthenticationService>();

                services.AddSingleton<Func<Type, BaseViewModel>>(
                    services => viewModelType => (BaseViewModel)services.GetRequiredService(viewModelType));
                
                
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
        MainWindow.DataContext = AppHost.Services.GetRequiredService<MainWindowViewModel>();
        startupForm.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}
