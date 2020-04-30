using Windows.UI.Xaml.Controls;

namespace DakboardKiosk.Views
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        public ViewModels.SettingsPageViewModel ViewModel 
            => DataContext as ViewModels.SettingsPageViewModel;
    }
}
