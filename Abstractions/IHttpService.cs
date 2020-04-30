using System.Threading.Tasks;

namespace DakboardKiosk.Abstractions
{
    public interface IHttpService
    {
        Task<string> GetAsync(string endpoint);

        Task<T> GetAsync<T>(string endpoint);
    }
}
