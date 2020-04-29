using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DakboardKiosk.Models;

namespace DakboardKiosk.Services.Abstractions
{
    public interface IDakService
    {
        Task<IEnumerable<Screen>> ListScreensAsync();

        Task<Uri> GetDefaultUriAsync();
    }
}