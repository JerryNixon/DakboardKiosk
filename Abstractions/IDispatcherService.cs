using System;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace DakboardKiosk.Abstractions
{
    public interface IDispatcherService
    {
        CoreDispatcher Dispatcher { get; set; }

        Task RunAsync(Action action);
    }
}
