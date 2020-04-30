using System;
using System.Linq;
using System.Threading.Tasks;
using DakboardKiosk.Abstractions;
using DakboardKiosk.Services;
using DakboardKiosk.ViewModels;
using DakboardKiosk.Views;
using Prism.Ioc;
using Template10;
using Template10.Ioc;
using Template10.Navigation;
using Template10.Services;
using Unity;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace DakboardKiosk
{
    public partial class App : ApplicationBase
    {
        public App() => InitializeComponent();

        public override void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterView<BrowserPage, BrowserPageViewModel>();
            container.RegisterView<SettingsPage, SettingsPageViewModel>();

            container.Register<ISettingsService, SettingsService>();
            container.Register<IDakService, DakService>();
            container.Register<IHttpService, HttpService>();
            container.Register<IRefreshService, RefreshService>();
            container.GetContainer().RegisterFactory<INavigationService>(e => NavigationService.Instances.First().Value);
        }

        private object Factory(IUnityContainer arg)
        {
            throw new NotImplementedException();
        }

        public override async Task OnStartAsync(IStartArgs args)
        {
            if (args.StartKind == StartKinds.Launch
                && args.Arguments is ILaunchActivatedEventArgs e
                && e != null)
            {
                var shell = new ShellPage(e.SplashScreen);
                Window.Current.Content = shell;
                Window.Current.Activate();

                await Task.Delay(1000);

                var frame = shell.MainFrame;
                var nav = NavigationFactory.Create(frame)
                    .AttachGestures(Window.Current, Gesture.Refresh);

                await nav.NavigateAsync(nameof(SettingsPage));
            }
        }
    }
}
