using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    public class AveragePriceResult
    {
        public int Hour { get; set; }
        public double AvgPrice { get; set; }

        public override string ToString()
        {
            return this.Hour.ToString() + " - " + this.AvgPrice.ToString();
        }

        public AveragePriceResult(double avgPrice)
        {
            this.AvgPrice = avgPrice;
        }
    }
}
