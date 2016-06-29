using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Maps;

using FuelRadar.Model;

namespace FuelRadar.Geo
{
    /// <summary>
    /// Provides the functionality to determine a coordinate for an address
    /// </summary>
    public static class GeoCoder
    {
        private static Geocoder Instance;

        public static async Task<GlobalCoordinate> GetPositionForAddress(String address)
        {
            // Singleton Xamarin Forms Geocoder
            if (GeoCoder.Instance == null) GeoCoder.Instance = new Geocoder();
            try
            {
                IEnumerable<Position> results = await GeoCoder.Instance.GetPositionsForAddressAsync(address);
                return results.First().ToGlobalCoordinate();
            }
            catch (Exception ex)
            {
                // If anything went wrong (maybe better error handling later)
                return null;
            }
        }

    }
}
