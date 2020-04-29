using Newtonsoft.Json;
using Windows.Storage;

namespace DakboardKiosk.Services
{
    public class SettingsHelper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "By design.")]
        public T Read<T>(string key, T otherwise = default)
        {
            try
            {
                var settings = ApplicationData.Current.LocalSettings.Values;
                if (!settings.ContainsKey(key))
                {
                    return otherwise;
                }

                var json = settings[key]?.ToString();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return otherwise;
            }
        }

        public void Write<T>(string key, T value)
        {
            var json = JsonConvert.SerializeObject(value);
            var settings = ApplicationData.Current.LocalSettings.Values;
            settings[key] = json;
        }
    }
}
