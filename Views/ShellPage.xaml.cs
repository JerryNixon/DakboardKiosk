using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DakboardKiosk.Views
{
    public sealed partial class ShellPage : Page
    {
        public ShellPage(SplashScreen splashScreen)
        {
            InitializeComponent();
            Window.Current.SizeChanged += (s, e) => SetupSplashScreen(splashScreen);
            SetupSplashScreen(splashScreen);
        }

        private void SetupSplashScreen(SplashScreen splashScreen)
        {
            SplashImage.Height = splashScreen.ImageLocation.Height;
            SplashImage.Width = splashScreen.ImageLocation.Width;
            SplashImage.SetValue(Canvas.TopProperty, splashScreen.ImageLocation.Top);
            SplashImage.SetValue(Canvas.LeftProperty, splashScreen.ImageLocation.Left);
        }

        private void SplashImage_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.Content = this;
            Window.Current.Activate();
        }

        private void MainFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            SplashImageContainer.Visibility = Visibility.Collapsed;
        }
    }
}
