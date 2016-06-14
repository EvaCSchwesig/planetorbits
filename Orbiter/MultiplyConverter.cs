using System;
using System.Globalization;
using System.Windows.Data;

namespace Orbiter
{
    public class MultiplyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return AsDouble(value) * AsDouble(parameter);
        }

        double AsDouble(object value)
        {
            var valueText = value as string;
            if (valueText != null)
                return double.Parse(valueText);
            else
                return (double)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotSupportedException();
        }
    }
}
