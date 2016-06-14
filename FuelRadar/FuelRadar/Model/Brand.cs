using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    public enum Brand
    {
        None,
        Shell,
        Aral,
        Total
    }

    public static class BrandHelpers
    {
        public static Brand FromString(String str)
        {
            return Brand.None;
        }
    }
}
