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

        public double GetPrice(FuelType type)
        {
            switch (type)
            {
                case FuelType.Diesel:
                    return this.Diesel;
                case FuelType.Super:
                    return this.E5;
                case FuelType.E10:
                    return this.E10;
                default:
                    throw new ArgumentException("Unknown fuel type");
            }
        }

        public Price(double diesel, double e5, double e10)
        {
            this.Diesel = diesel;
            this.E5 = e5;
            this.E10 = e10;
        }
    }
}
