using System.Diagnostics;
using Newtonsoft.Json;
using Windows.Foundation.Collections;
using Windows.Storage;

namespace DakboardKiosk.Helpers
{
    public class SettingsHelper
    {
        private IPropertySet _settings;

        public SettingsHelper()
        {
            _settings = ApplicationData.Current.LocalSettings.Values;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "By design.")]
        public T Read<T>(string key, T otherwise = default)
        {
            if (_settings.ContainsKey(key))
            {
                try
                {
                    var value = _settings[key];
                    var json = value?.ToString();
                    return JsonConvert.DeserializeObject<T>(json);
                }
                catch
                {
                    Debugger.Break();
                    return otherwise;
                }
            }
            else
            {
                return otherwise;
            }
        }

        public bool Write<T>(string key, T value)
        {
            if (Equals(value, default(T)) && _settings.ContainsKey(key))
            {
                _settings.Remove(key);
                return true;
            }

            if (Equals(Read<T>(key, default), value))
            {
                return false;
            }

            var json = JsonConvert.SerializeObject(value);
            _settings[key] = json;
            return true;
        }
    }
}
