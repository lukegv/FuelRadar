using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    /// <summary>
    /// Represents a global coordinate (latitude and longitude)
    /// </summary>
    public class GlobalCoordinate
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public GlobalCoordinate(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public Xamarin.Forms.Maps.Position ToMapsPosition()
        {
            return new Xamarin.Forms.Maps.Position(this.Latitude, this.Longitude);
        }

    }

    public static class GlobalCoordinateHelpers
    {
        public static GlobalCoordinate ToGlobalCoordinate(this Xamarin.Forms.Maps.Position position)
        {
            return new GlobalCoordinate(position.Latitude, position.Longitude);
        }

        public static GlobalCoordinate ToGlobalCoordinate(this Plugin.Geolocator.Abstractions.Position position)
        {
            return new GlobalCoordinate(position.Latitude, position.Longitude);
        }
    }
}
