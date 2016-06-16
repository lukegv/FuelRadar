using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    public class GlobalCoordinate
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public GlobalCoordinate(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public GlobalCoordinate(Xamarin.Forms.Maps.Position position)
        {
            this.Latitude = position.Latitude;
            this.Longitude = position.Longitude;
        }

        public Xamarin.Forms.Maps.Position ToPosition()
        {
            return new Xamarin.Forms.Maps.Position(this.Latitude, this.Longitude);
        }

    }
}
