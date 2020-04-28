using DakboardKiosk.Models;
using DakboardKiosk.Services.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DakboardKiosk.Services
{
    public class DakService : IDakService
    {
        ISecretService _secretService;

        public async Task<IEnumerable<Screen>> GetScreensAsync()
        {
            var key = _secretService.Read(Enums.Secret.ApiKey);
            if (string.IsNullOrEmpty(key))
            {
                // todo
            }

            // https://blog.dakboard.com/new-dakboard-api/
            var url = $"https://dakboard.com/api/2/screens?api_key={key}";

            var http = new HttpClient();
            var json = await http.GetStringAsync(url);
            return JsonConvert.DeserializeObject<Screen[]>(json);
        }

        public async Task<Uri> GetDefaultUriAsync()
        {
            var screens = await GetScreensAsync();
            var screen = screens.First(x => x.IsDefault == 1);
            var url = $"https://www.dakboard.com/app/screenPredefined?p={screen.Id}";
            return new Uri(url);
        }
    }
}
