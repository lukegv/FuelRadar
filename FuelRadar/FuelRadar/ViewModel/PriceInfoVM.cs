using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PropertyChanged;

using FuelRadar.Model;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class PriceInfoVM
    {
        public String Name
        {
            get
            {
                return this.RepresentedObject.GasStation.Name;
            }
        }

        public GlobalCoordinate Location
        {
            get
            {
                return this.RepresentedObject.GasStation.Location;
            }
        }

        public Brand Brand
        {
            get
            {
                return this.RepresentedObject.GasStation.Brand;
            }
        }

        public double MainPrice
        {
            get
            {
                return this.RepresentedObject.CurrentPrice.Diesel;
            }
        }

        public String MainPriceString
        {
            get
            {
                return this.MainPrice.ToString() + " €";
            }
        }

        private PriceInfo RepresentedObject { get; set; }

        public PriceInfoVM(PriceInfo repObject)
        {
            this.RepresentedObject = repObject;
        }

        public void UpdatePrice(Price price)
        {
            this.RepresentedObject.UpdatePrice(price);
            // update prices
        }

    }
}
