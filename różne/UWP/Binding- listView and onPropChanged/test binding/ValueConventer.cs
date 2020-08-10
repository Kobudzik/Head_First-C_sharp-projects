using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace test_binding
{
    class ValueConventer : IValueConverter
    {
     

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            int returnedValue;

            if (int.TryParse((string)value, out returnedValue))
            {
                return returnedValue;
            }

            throw new Exception("The text is not a number");
        }
    }
}