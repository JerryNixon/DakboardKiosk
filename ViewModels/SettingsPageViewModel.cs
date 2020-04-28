using DakboardKiosk.Services.Abstractions;
using DakboardKiosk.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakboardKiosk.ViewModels
{
    public class SettingsPageViewModel
    {
        ISecretService _secretService;

        public string ApiKey
        {
            get => _secretService.Read(Secret.ApiKey);
            set => _secretService.Write(Secret.ApiKey, value);
        }

        public 
    }
}
