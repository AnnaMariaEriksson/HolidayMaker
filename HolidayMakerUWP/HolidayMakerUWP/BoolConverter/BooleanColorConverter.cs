using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace HolidayMakerUWP.BoolConverter
{
    public class BooleanColorConverter : IValueConverter
    {
        public BooleanColorConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Debug.WriteLine(value);
            SolidColorBrush color;
            if (value is bool && (bool)value)
            {
                color = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 48, 179, 221));
            }
            else
            {
                color = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 204, 204, 204));
            }
            return color;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
