using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    public class Station
    {
        public String ID { get; private set; }

        public String Name { get; private set; }

        public Brand Brand { get; private set; }

        public GlobalCoordinate Location { get; private set; }

        public Station(String id, String name, String brand, double latitude, double longitude)
        {
            this.ID = id;
            this.Name = name;
            this.Brand = BrandHelpers.FromString(brand);
            this.Location = new GlobalCoordinate(latitude, longitude);
        }

        public Station(String id, String name, int brand, double latitude, double longitude)
        {
            this.ID = id;
            this.Name = name;
            this.Brand = (Brand)brand;
            this.Location = new GlobalCoordinate(latitude, longitude);
        }
    }
}
