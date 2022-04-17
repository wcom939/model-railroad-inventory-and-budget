using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ModelRailroadBudgetAndInventory
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        /// <inheritdoc/>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            // Ensure the UI is initialized
            if (Window.Current.Content is null)
            {
                Window.Current.Content = new Shell();
                /*
                TitleBarHelper.StyleTitleBar();
                TitleBarHelper.ExpandViewIntoTitleBar();

                // Register services
                Ioc.Default.ConfigureServices(
                    new ServiceCollection()
                        .AddSingleton<IDialogService, DialogService>() //Services
                        .AddSingleton<IFilesService, FilesService>()
                        .AddSingleton<ISettingsService, SettingsService>()
                        .AddSingleton(RestService.For<IRedditService>("https://www.reddit.com/"))
                        .AddSingleton(RestService.For<IContactsService>("https://randomuser.me/"))
                        .AddTransient<PostWidgetViewModel>() //ViewModels
                        .AddTransient<SubredditWidgetViewModel>()
                        .AddTransient<ContactsListWidgetViewModel>()
                        .AddTransient<AsyncRelayCommandPageViewModel>()
                        .AddTransient<IocPageViewModel>()
                        .AddTransient<MessengerPageViewModel>()
                        .AddTransient<ObservableObjectPageViewModel>()
                        .AddTransient<ObservableValidatorPageViewModel>()
                        .AddTransient<ValidationFormWidgetViewModel>()
                        .AddTransient<RelayCommandPageViewModel>()
                        .AddTransient<CollectionsPageViewModel>()
                        .AddTransient<SamplePageViewModel>()
                        .BuildServiceProvider());*/
            }

            // Enable the prelaunch if needed, and activate the window
            if (e.PrelaunchActivated == false)
            {
                CoreApplication.EnablePrelaunch(true);

                Window.Current.Activate();
            }
        }
    }

}
