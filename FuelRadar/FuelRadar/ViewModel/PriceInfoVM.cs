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
        public Station GasStation
        {
            get
            {
                return this.RepresentedObject.GasStation;
            }
        }

        public Price CurrentPrice
        {
            get
            {
                return this.RepresentedObject.CurrentPrice;
            }
            set
            {
                this.RepresentedObject.UpdatePrice(value);
            }
        }

        private PriceInfo RepresentedObject { get; set; }

        public PriceInfoVM(PriceInfo repObject)
        {
            this.RepresentedObject = repObject;
        }

        public void UpdatePrice(Price price)
        {
            this.CurrentPrice = price;
        }

    }
}
