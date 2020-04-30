using System;
using System.Net.Http;
using System.Threading.Tasks;
using DakboardKiosk.Abstractions;
using Newtonsoft.Json;

namespace DakboardKiosk.Services
{
    public class HttpService : IHttpService
    {
        private readonly ISettingsService _settingsService;

        public HttpService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var json = await GetAsync(endpoint);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<string> GetAsync(string endpoint)
        {
            var uri = AppendApiKey();
            try
            {
                return await GetStringAsync();
            }
            catch (Exception ex) when (ex.Message.Contains("ApiKey"))
            {
                throw new Exceptions.InvalidApiKeyException();
            }
            catch
            {
                throw;
            }

            Uri AppendApiKey()
            {
                _ = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
                if (!Uri.TryCreate(endpoint, UriKind.RelativeOrAbsolute, out _))
                {
                    throw new ArgumentException("Invalid Uri.", nameof(endpoint));
                }

                var key = _settingsService.ApiKey ?? throw new NullReferenceException("ApiKey");
                return new Uri($"{endpoint}?api_key={key}");
            }

            async Task<string> GetStringAsync()
            {
                var http = new HttpClient
                {
                    Timeout = TimeSpan.FromMinutes(1),
                };
                return await http.GetStringAsync(uri);
            }
        }
    }
}
