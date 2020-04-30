using System;
using DakboardKiosk.Abstractions;
using DakboardKiosk.Messages;
using Prism.Events;
using Template10.Mvvm;
using Template10.Navigation;

namespace DakboardKiosk.ViewModels
{
    public class BrowserPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRefreshService _refreshService;

        public BrowserPageViewModel(IRefreshService refreshService, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _refreshService = refreshService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _eventAggregator.GetEvent<NavigateBrowser>().Subscribe(HandleNavigateBrowser);
            _refreshService.Start();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            _eventAggregator.GetEvent<NavigateBrowser>().Unsubscribe(HandleNavigateBrowser);
            _refreshService.Stop();
        }

        private void HandleNavigateBrowser(Uri uri) => NavigateCallback?.Invoke(uri);

        public Action<Uri> NavigateCallback { get; set; }
    }
}
