using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    public class PriceInfo
    {
        public Station GasStation { get; private set; }

        public Price CurrentPrice { get; private set; }

        public PriceInfo(Station station, Price price)
        {
            this.GasStation = station;
            this.CurrentPrice = price;
        }
    }
}
