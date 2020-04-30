using System.Collections.Generic;
using System.Threading.Tasks;
using DakboardKiosk.Models;

namespace DakboardKiosk.Abstractions
{
    public interface IDakService
    {
        Task<IEnumerable<Screen>> GetScreensAsync();

        Task<Screen> GetScreenAsync(string screenId);

        Task<Screen> GetDefaultScreenAsync();

        Task<bool> ValidateApiKeyAsync();
    }
}
