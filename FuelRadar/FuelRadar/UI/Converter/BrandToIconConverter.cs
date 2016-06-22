using FuelRadar.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FuelRadar.UI.Converter
{
    public class BrandToIconConverter : IValueConverter
    {
        private static String[] Icons = new String[]
        {
            "FuelRadar.UI.Images.BrandIcons.brandNone.png", // None
            "FuelRadar.UI.Images.BrandIcons.brandShell.png", // Shell
            "FuelRadar.UI.Images.BrandIcons.brandAral.png" // Aral
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Brand)
            {
                return ImageSource.FromResource(Icons[(int)value]);
            }
            else throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
