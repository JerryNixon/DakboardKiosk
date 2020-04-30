using System;
using System.ComponentModel;

namespace DakboardKiosk.Abstractions
{
    public interface ISettingsService : INotifyPropertyChanged
    {
        string ApiKey { get; set; }

        string ScreenUrl { get; set; }

        TimeSpan RefreshRate { get; set; }
    }
}
