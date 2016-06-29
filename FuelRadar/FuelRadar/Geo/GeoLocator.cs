using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

using FuelRadar.Model;

namespace FuelRadar.Geo
{
    /// <summary>
    /// Provides the functionality to determine the current device location
    /// </summary>
    public static class GeoLocator
    {
        private const int TIMEOUT = 10000;

        public static async Task<GlobalCoordinate> GetCurrentPosition()
        {
            try
            {
                Position position = await CrossGeolocator.Current.GetPositionAsync(TIMEOUT);
                return position.ToGlobalCoordinate();
            }
            catch (Exception ex)
            {
                // if anything went wrong (maybe better error handling later)
                return null;
            }
        }
    }
}
