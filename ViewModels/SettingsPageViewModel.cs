using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DakboardKiosk.Abstractions;
using DakboardKiosk.Models;
using Prism.Events;
using Template10.Mvvm;
using Template10.Navigation;

namespace DakboardKiosk.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private readonly IDakService _dakService;
        private readonly IEventAggregator _eventAggregator;
        private bool _validApiKey = false;
        private bool _validateBusy = false;
        private bool _listBusy = false;

        public SettingsPageViewModel(ISettingsService settingsService, IDakService dakService, IEventAggregator eventAggregator)
        {
            Settings = settingsService;
            _dakService = dakService;
            _eventAggregator = eventAggregator;
            Settings.PropertyChanged += async (s, e) =>
            {
                if (e.PropertyName == nameof(ISettingsService.ApiKey))
                {
                    if (Settings.ApiKey.Length == 48)
                    {
                        await FillScreensAsync();
                    }
                    else
                    {
                        ValidApiKey = false;
                    }
                }
            };
        }

        public override async Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await FillScreensAsync();
        }

        public ISettingsService Settings { get; }

        public ObservableCollection<Screen> Screens { get; } = new ObservableCollection<Screen>();

        public bool ListBusy
        {
            get => _listBusy;
            set => SetProperty(ref _listBusy, value);
        }

        public bool ValidateBusy
        {
            get => _validateBusy;
            set => SetProperty(ref _validateBusy, value);
        }

        public Screen SelectedScreen
        {
            get => Screens.FirstOrDefault(x => x.Url.ToString() == Settings.ScreenUrl);
            set
            {
                if (SelectedScreen != value)
                {
                    Settings.ScreenUrl = value?.Url.ToString();
                }
            }
        }

        public async Task FillScreensAsync()
        {
            ListBusy = true;
            try
            {
                if (!ValidApiKey)
                {
                    await ValidateApiKeyAsync();
                    if (!ValidApiKey)
                    {
                        return;
                    }
                }

                if (string.IsNullOrEmpty(Settings.ApiKey))
                {
                    return;
                }

                var screens = await _dakService.GetScreensAsync();
                Screens.Clear();
                foreach (var screen in screens)
                {
                    Screens.Add(screen);
                }

                RaisePropertyChanged(nameof(SelectedScreen));
            }
            catch
            {
                Screens.Clear();
            }
            finally
            {
                ListBusy = false;
            }
        }

        public void RefreshBrowser()
        {
            var url = Settings.ScreenUrl ?? "https://www.dakboard.com/app/screenPredefined";
            _eventAggregator
                .GetEvent<Messages.NavigateBrowser>()
                .Publish(new System.Uri(url));
            GotoBrowserPage();
        }

        public bool ValidApiKey
        {
            get => _validApiKey;
            set
            {
                SetProperty(ref _validApiKey, value);
                if (!value)
                {
                    Screens.Clear();
                }
            }
        }

        public async Task ValidateApiKeyAsync()
        {
            ValidateBusy = true;
            try
            {
                ValidApiKey = await _dakService.ValidateApiKeyAsync();
            }
            finally
            {
                ValidateBusy = false;
            }
        }

        public void GotoBrowserPage()
        {
            NavigationService.NavigateAsync(nameof(Views.BrowserPage));
        }
    }
}
