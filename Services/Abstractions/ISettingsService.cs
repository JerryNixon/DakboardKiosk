using System;

namespace DakboardKiosk.Services.Abstractions
{
    public interface ISettingsService
    {
        string ApiKey { get; set; }

        TimeSpan RefreshRate { get; set; }
    }
}