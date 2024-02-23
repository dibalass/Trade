using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Documents;
using Trade.Models;

namespace Trade.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filename = value as string;
            if (filename == "нет")
            {
                return Environment.CurrentDirectory + @"\Images\nophoto.jpg";
            }
            return Environment.CurrentDirectory + @"\Images\" + filename;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
