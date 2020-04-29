using DakboardKiosk.Messages;
using DakboardKiosk.Services.Abstractions;
using Prism.Events;
using Template10.Mvvm;
using Template10.Navigation;
using Windows.UI.Xaml;

namespace DakboardKiosk.ViewModels
{
    public class BrowserPageViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDakService _dakService;
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public BrowserPageViewModel(ISettingsService settingsService, IEventAggregator eventAggregator, IDakService dakService)
        {
            _settingsService = settingsService;
            _eventAggregator = eventAggregator;
            _dakService = dakService;
            _timer.Tick += Timer_Tick;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _timer.Interval = _settingsService.RefreshRate;
            _timer.Start();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            _timer.Stop();
        }

        private async void Timer_Tick(object sender, object e)
        {
            var url = await _dakService.GetDefaultUriAsync();
            _eventAggregator.GetEvent<RefreshBrowser>().Publish(url);
        }
    }
}
