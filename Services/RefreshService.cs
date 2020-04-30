using System;
using DakboardKiosk.Abstractions;
using Prism.Events;
using Windows.UI.Xaml;

namespace DakboardKiosk.Services
{
    public class RefreshService : IRefreshService
    {
        private readonly ISettingsService _settingsService;
        private readonly IEventAggregator _eventAggregator;
        private readonly DispatcherTimer _timer;

        public RefreshService(ISettingsService settingsService, IEventAggregator eventAggregator)
        {
            _settingsService = settingsService;
            _eventAggregator = eventAggregator;
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMinutes(1),
            };
            _timer.Tick += Timer_Tick;
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void Timer_Tick(object sender, object e)
        {
            if (_settingsService.RefreshRate.TotalMinutes == DateTime.Now.TimeOfDay.TotalMinutes)
            {
                var uri = new Uri(_settingsService.ScreenUrl);
                _eventAggregator.GetEvent<Messages.NavigateBrowser>().Publish(uri);
            }
        }
    }
}
