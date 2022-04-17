using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NavigationView = Microsoft.UI.Xaml.Controls.NavigationView;
using NavigationViewBackRequestedEventArgs = Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs;
using NavigationViewItemInvokedEventArgs = Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ModelRailroadBudgetAndInventory
{
    public sealed partial class Shell : UserControl
    {
        private readonly IReadOnlyCollection<SampleEntry> NavigationItems;

        public Shell()
        {
            this.InitializeComponent();

            /*NavigationItems = new[]
            {
            new SampleEntry(IntroductionItem, typeof(IntroductionPage)),
            new SampleEntry(ObservableObjectItem, typeof(ObservableObjectPage), "ObservableObject", "observable inotify property changed propertychanging changing"),
            new SampleEntry(ObservableValidatorItem, typeof(ObservableValidatorPage), "ObservableValidator", "observable form validation validate data error inotify property changed propertychanging changing"),
            new SampleEntry(CommandsItem, typeof(RelayCommandPage), "RelayCommand and RelayCommand<T>", "commands icommand relaycommand binding"),
            new SampleEntry(AsyncCommandsItem, typeof(AsyncRelayCommandPage), "AsyncRelayCommand and AsyncRelayCommand<T>", "asynccommands icommand relaycommand binding asynchronous"),
            new SampleEntry(MessengerItem, typeof(MessengerPage), "Messenger and IMessenger", "messenger messaging message receiver recipient"),
            new SampleEntry(SendMessagesItem, typeof(MessengerSendPage), "[IMessenger] Send messages", "messenger messaging message receiver recipient send"),
            new SampleEntry(RequestMessagesItem, typeof(MessengerRequestPage), "[IMessenger] Request messages", "messenger messaging message receiver recipient request reply"),
            new SampleEntry(InversionOfControlItem, typeof(IocPage), "Ioc (Inversion of control)", "ioc inversion control dependency injection service locator"),
            new SampleEntry(CollectionsItem, typeof(CollectionsPage), "Collections", "collection observable mvvm group list grid items source"),
            new SampleEntry(RedditBrowserOverviewItem, typeof(PuttingThingsTogetherPage), "Putting things together"),
            new SampleEntry(ViewModelsSetupItem, typeof(SettingUpTheViewModelsPage), "Setting up the ViewModels"),
            new SampleEntry(SettingsServiceItem, typeof(SettingsServicePage), "Settings service"),
            new SampleEntry(RedditServiceItem, typeof(RedditServicePage), "Reddit service"),
            new SampleEntry(BuildingTheUIItem, typeof(BuildingTheUIPage), "Building the UI"),
            new SampleEntry(FinalResultItem, typeof(RedditBrowserPage), "Reddit browser")
        };*/

            // Set the custom title bar to act as a draggable region
            Window.Current.SetTitleBar(TitleBarBorder);
        }

        // Navigates to a sample page when a button is clicked
        private void NavigationView_OnItemInvoked(NavigationView navigationView, NavigationViewItemInvokedEventArgs navigationViewItemInvokedEventArgs)
        {
            /*if (NavigationItems.FirstOrDefault(item => item.Item == navigationViewItemInvokedEventArgs.InvokedItemContainer)?.PageType is Type pageType)
            {
                NavigationFrame.Navigate(pageType);
            }*/
        }

        // Sets whether or not the back button is enabled
        private void NavigationFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            NavigationView.IsBackEnabled = ((Frame)sender).BackStackDepth > 0;
        }

        // Navigates back
        private void NavigationView_OnBackRequested(Microsoft.UI.Xaml.Controls.NavigationView navigationView, NavigationViewBackRequestedEventArgs navigationViewBackRequestedEventArgs)
        {
            if (NavigationFrame.BackStack.LastOrDefault() is PageStackEntry entry)
            {
                NavigationView.SelectedItem = NavigationItems.First(item => item.PageType == entry.SourcePageType).Item;

                NavigationFrame.GoBack();
            }
        }

        // Select the introduction item when the shell is loaded
        private void Shell_OnLoaded(object sender, RoutedEventArgs e)
        {
            NavigationView.SelectedItem = SettingsItem;

            /*NavigationFrame.Navigate(typeof(IntroductionPage));*/
        }

        // Updates the search results
        private void SearchBox_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                // Not a simple tokenized search, but good enough for now
                string query = sender.Text.ToLowerInvariant();

                sender.ItemsSource = NavigationItems.Where(item => item.Tags?.Contains(query) == true);
            }
        }

        // Navigates to a selected item
        private void AutoSuggestBox_OnSuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            SampleEntry entry = (SampleEntry)args.SelectedItem;

            NavigationFrame.Navigate(entry.PageType);

            NavigationView.SelectedItem = entry.Item;

            sender.Text = string.Empty;
        }
    }


    /// <summary>
    /// A simple model for tracking sample pages associated with buttons.
    /// </summary>
    public sealed class SampleEntry
    {
        public SampleEntry(NavigationViewItem viewItem, Type pageType, string? name = null, string? tags = null)
        {
            Item = viewItem;
            PageType = pageType;
            Name = name;
            Tags = tags;
        }

        /// <summary>
        /// The navigation item for the current entry.
        /// </summary>
        public NavigationViewItem Item { get; }

        /// <summary>
        /// The associated page type for the current entry.
        /// </summary>
        public Type PageType { get; }

        /// <summary>
        /// Gets the name of the current entry.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Gets the tag for the current entry, if any.
        /// </summary>
        public string? Tags { get; }
    }

}
