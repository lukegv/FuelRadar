using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using FuelRadar.Model;

namespace FuelRadar.UI.Converter
{
    public class BrandToColorConverter : IValueConverter
    {
        private static Color[] ForegroundColor = new Color[]
        {
            Color.Black, // None
            Color.FromHex("ED1C24"), // Shell
            Color.White // Aral
        };

        private static Color[] BackgroundColor = new Color[]
        {
            Color.White, // None
            Color.FromHex("FFD500"), // Shell
            Color.FromHex("0082EE") // Aral
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Brand)
            {
                if ((string)parameter == "fore") return ForegroundColor[(int)value];
                if ((string)parameter == "back") return BackgroundColor[(int)value];
                throw new ArgumentException("Neither fore not back specified");
            }
            else throw new ArgumentException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // back conversion not supported
            throw new NotSupportedException();
        }
    }
}
