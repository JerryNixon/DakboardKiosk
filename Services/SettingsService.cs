using System;
using DakboardKiosk.Abstractions;
using DakboardKiosk.Exceptions;
using DakboardKiosk.Helpers;
using Prism.Mvvm;
using Template10.Services;

namespace DakboardKiosk.Services
{
    public class SettingsService : BindableBase, ISettingsService
    {
        private readonly SecretHelper _secretHelper = new SecretHelper();
        private readonly SettingsHelper _settingsHelper = new SettingsHelper();

        public string ApiKey
        {
            get => ReadSecret(nameof(ApiKey));
            set
            {
                if (_secretHelper.IsSecretExistsForKey(nameof(ApiKey)) 
                    && Equals(_secretHelper.ReadSecret(nameof(ApiKey)), value))
                {
                    return;
                }

                _secretHelper.WriteSecret(nameof(ApiKey), value);
                RaisePropertyChanged();
            }
        }

        public TimeSpan RefreshRate
        {
            get => _settingsHelper.Read(nameof(RefreshRate), TimeSpan.FromHours(1));
            set
            {
                if (_settingsHelper.Write(nameof(RefreshRate), value))
                {
                    RaisePropertyChanged();
                }
            }
        }

        public string ScreenUrl
        {
            get => _settingsHelper.Read(nameof(ScreenUrl), string.Empty);
            set
            {
                if (_settingsHelper.Write(nameof(ScreenUrl), value))
                {
                    RaisePropertyChanged();
                }
            }
        }

        private string ReadSecret(string key)
        {
            if (_secretHelper.IsSecretExistsForKey(key))
            {
                return _secretHelper.ReadSecret(key)
                    ?? throw new SecretNotFoundException($"Secret.{key}");
            }
            else
            {
                var vars = Environment.GetEnvironmentVariables();
                key = $"{nameof(DakboardKiosk)}_{key}";
                if (vars.Contains(key))
                {
                    return Environment.GetEnvironmentVariable(key)
                        ?? throw new SecretNotFoundException($"Environment.{key} is null.");
                }
                else
                {
                    throw new SecretNotFoundException($"Environment.{key} not found.");
                }
            }
        }
    }
}
