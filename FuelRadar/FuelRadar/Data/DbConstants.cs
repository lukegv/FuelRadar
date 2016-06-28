using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Data
{
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
    }
}
