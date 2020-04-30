using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DakboardKiosk.Abstractions;
using DakboardKiosk.Models;

namespace DakboardKiosk.Services
{
    // https://blog.dakboard.com/new-dakboard-api/
    public class DakService : IDakService
    {
        private readonly IHttpService _httpService;

        public DakService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<bool> ValidateApiKeyAsync()
        {
            try
            {
                var url = $"https://dakboard.com/api/2/screens";
                await _httpService.GetAsync(url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Screen>> GetScreensAsync()
        {
            var url = $"https://dakboard.com/api/2/screens";
            return await _httpService.GetAsync<Screen[]>(url);
        }

        public async Task<Screen> GetScreenAsync(string screenId)
        {
            var url = $"https://dakboard.com/api/2/screens/{screenId}";
            return await _httpService.GetAsync<Screen>(url);
        }

        public async Task<Screen> GetDefaultScreenAsync()
        {
            var screens = await GetScreensAsync();
            return screens.First(x => x.IsDefault == 1);
        }
    }
}
