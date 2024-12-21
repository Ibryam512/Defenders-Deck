using System.Globalization;

namespace DefendersDeck.App.Converters
{
    public class InvertedBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ReturnValue(value);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => ReturnValue(value);

        private bool ReturnValue(object value)
        {
            if (value is bool boolValue)
            {
                return !boolValue;
            }
            return false;
        }
    }
}
