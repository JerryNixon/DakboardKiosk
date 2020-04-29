using DakboardKiosk.Services.Abstractions;
using Template10.Mvvm;
using Template10.Navigation;

namespace DakboardKiosk.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(ISettingsService settingsService)
        {
            Settings = settingsService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            // todo
        }

        public ISettingsService Settings { get; }
    }
}
