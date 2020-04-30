using System;
using System.Threading.Tasks;
using DakboardKiosk.Abstractions;
using Windows.UI.Core;

namespace DakboardKiosk.Services
{
    public class DispatcherService : IDispatcherService
    {
        public CoreDispatcher Dispatcher { get; set; }

        public async Task RunAsync(Action action)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
        }
    }
}
