using DakboardKiosk.Services.Abstractions;
using DakboardKiosk.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakboardKiosk.Services
{
    public class SecretService : ISecretService
    {
        public string Read(Secret key)
        {
            throw new NotImplementedException();
        }

        public void Write(Secret key, string value)
        {
            throw new NotImplementedException();
        }
    }
}
