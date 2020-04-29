using DakboardKiosk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DakboardKiosk.Services.Abstractions
{
    public interface IDakService
    {
        Task<IEnumerable<Screen>> ListScreensAsync();

        Task<Uri> GetDefaultUriAsync();
    }
}