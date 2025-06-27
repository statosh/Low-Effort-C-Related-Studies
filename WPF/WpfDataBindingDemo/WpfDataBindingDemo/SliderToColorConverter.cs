using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfDataBindingDemo {
    public class SliderToColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            byte intensity = (byte)(double)value;
            return Color.FromRgb(intensity, 100, 150);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
