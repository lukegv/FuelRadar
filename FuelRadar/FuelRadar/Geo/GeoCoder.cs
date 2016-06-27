using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Maps;

using FuelRadar.Model;

namespace FuelRadar.Geo
{
    public static class GeoCoder
    {
        private static Geocoder Instance;

        public static async Task<GlobalCoordinate> GetPositionForAddress(String address)
        {
            if (GeoCoder.Instance == null) GeoCoder.Instance = new Geocoder();
            try
            {
                IEnumerable<Position> results = await GeoCoder.Instance.GetPositionsForAddressAsync(address);
                return results.First().ToGlobalCoordinate();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
