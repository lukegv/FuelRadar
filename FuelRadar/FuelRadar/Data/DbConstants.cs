using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Data
{
    /// <summary>
    /// Contains all constants used in the database
    /// </summary>
    public static class DbConstants
    {
        public const String FavoriteStationsTable = "favorite_stations";

        public static class FavoriteStations
        {
            public const String Id = "id";
            public const String Name = "name";
            public const String Brand = "brand";
            public const String Latitude = "lat";
            public const String Longitude = "long";
        }

        public const String PriceHistoryTable = "price_history";

        public static class PriceHistory
        {
            public const String Id = "id";
            public const String Timestamp = "timestamp";
            public const String GasStation = "gasstation";
            public const String Latitude = "lat";
            public const String Longitude = "long";
            public const String DieselPrice = "diesel";
            public const String E5Price = "e5";
            public const String E10Price = "e10";
        }
    }
}
