using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    public class Price
    {
        public double Diesel { get; private set; }
        public double E5 { get; private set; }
        public double E10 { get; private set; }


        public Price(double diesel, double e5, double e10)
        {
            this.Diesel = diesel;
            this.E5 = e5;
            this.E10 = e10;
        }
    }
}
