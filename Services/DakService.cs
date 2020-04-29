using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DakboardKiosk.Models;
using DakboardKiosk.Services.Abstractions;
using Newtonsoft.Json;

namespace DakboardKiosk.Services
{
    // https://blog.dakboard.com/new-dakboard-api/
    public class DakService : IDakService
    {
        private readonly ISettingsService _settingsService;

        public DakService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public async Task<IEnumerable<Screen>> ListScreensAsync()
        {
            var key = _settingsService.ApiKey ?? throw new NullReferenceException("ApiKey");
            var url = $"https://dakboard.com/api/2/screens?api_key={key}";
            var http = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(1),
            };
            var json = await http.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Screen[]>(json);
        }

        public async Task<Uri> GetDefaultUriAsync()
        {
            var screens = await ListScreensAsync();
            var screen = screens.First(x => x.IsDefault == 1);
            var url = $"https://www.dakboard.com/app/screenPredefined?p={screen.Id}";
            return new Uri(url);
        }
    }
}
