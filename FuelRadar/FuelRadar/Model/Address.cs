using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    public class Address
    {
        public String Street { get; private set; }

        public String Town { get; private set; }

        public Address(String street, String town)
        {
            this.Street = street;
            this.Town = town;
        }
    }
}
