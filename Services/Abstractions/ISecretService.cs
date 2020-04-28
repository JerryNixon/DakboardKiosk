using DakboardKiosk.Services.Enums;

namespace DakboardKiosk.Services.Abstractions
{
    public interface ISecretService
    {
        string Read(Secret key);
        void Write(Secret key, string value);
    }
}