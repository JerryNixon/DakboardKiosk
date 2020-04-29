using System;
using DakboardKiosk.Services.Abstractions;
using Template10.Services;

namespace DakboardKiosk.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly SecretHelper _secretHelper = new SecretHelper();
        private readonly SettingsHelper _settingsHelper = new SettingsHelper();

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
