using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.Settings;

using FuelRadar.Model;

namespace FuelRadar.Settings
{
    /// <summary>
    /// Provides access to the settings of the app
    /// </summary>
    public static class AppSettings
    {
        private const String FuelTypeKey = "fuelType";
        private static readonly int FuelTypeDefault = 0;

        /// <summary>
        /// The user selected fuel type
        /// </summary>
        public static FuelType FuelType
        {
            get { return (FuelType)CrossSettings.Current.GetValueOrDefault<int>(FuelTypeKey, FuelTypeDefault); }
            set { CrossSettings.Current.AddOrUpdateValue<int>(FuelTypeKey, (int)value); }
        }
    }
}
