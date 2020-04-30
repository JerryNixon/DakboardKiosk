using Windows.UI.Xaml.Controls;

namespace DakboardKiosk.Views
{
    public sealed partial class BrowserPage : Page
    {
        public BrowserPage()
        {
            InitializeComponent();
            DataContextChanged += (s, e)
                => ViewModel.NavigateCallback = (uri) => MainWebView.Navigate(uri);
        }

        public ViewModels.BrowserPageViewModel ViewModel 
            => DataContext as ViewModels.BrowserPageViewModel;
    }
}
