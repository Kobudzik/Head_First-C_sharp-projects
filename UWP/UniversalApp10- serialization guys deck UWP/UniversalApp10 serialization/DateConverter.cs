using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml.Data;

namespace UniversalApp10_serialization
{
    class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)//converts date to string
        {
         
            return value.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        var s = (string)value;
        return (DateTime.Parse(s));
    }

    }
}
