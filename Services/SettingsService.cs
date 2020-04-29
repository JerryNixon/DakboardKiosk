using DakboardKiosk.Services.Abstractions;
using System;
using Template10.Services;

namespace DakboardKiosk.Services
{
    public class SettingsService : ISettingsService
    {
        SecretHelper _secretHelper = new SecretHelper();
        SettingsHelper _settingsHelper = new SettingsHelper();

        public string ApiKey
        {
            get => _secretHelper.ReadSecret(nameof(ApiKey));
            set => _secretHelper.WriteSecret(nameof(ApiKey), value);
        }

        public TimeSpan RefreshRate
        {
            get => _settingsHelper.Read(nameof(RefreshRate), TimeSpan.FromHours(1));
            set => _settingsHelper.Write(nameof(RefreshRate), value);
        }
    }
}
