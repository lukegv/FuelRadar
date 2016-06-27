using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.Settings;

using FuelRadar.Model;

namespace FuelRadar.Settings
{
    public static class AppSettings
    {
        private const String FuelTypeKey = "fuelType";
        private static readonly int FuelTypeDefault = 0;

        public static FuelType FuelType
        {
            get { return (FuelType)CrossSettings.Current.GetValueOrDefault<int>(FuelTypeKey, FuelTypeDefault); }
            set { CrossSettings.Current.AddOrUpdateValue<int>(FuelTypeKey, (int)value); }
        }
    }
}
