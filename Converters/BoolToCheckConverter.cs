using System;
using Windows.UI.Xaml.Data;

namespace DakboardKiosk.Converters
{
    public class BoolToCheckConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Equals(value, true) ? "✔" : "❌";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
