using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;

namespace DakboardKiosk.Views
{

    public static class Extensions
    {
        public static void Match(this Image image, SplashScreen splashScreen)
        {
            image.Height = splashScreen.ImageLocation.Height;
            image.Width = splashScreen.ImageLocation.Width;
            image.SetValue(Canvas.TopProperty, splashScreen.ImageLocation.Top);
            image.SetValue(Canvas.LeftProperty, splashScreen.ImageLocation.Left);
        }
    }
}
