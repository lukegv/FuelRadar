using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    /// <summary>
    /// Represents a gas station brand
    /// </summary>
    public enum Brand
    {
        None = 0,
        Shell = 1,
        Aral = 2
        /* Esso = 3,
         Total = 4,
         BP = 5,
         Jet = 6 */
    }

    public static class BrandHelpers
    {
        public static Brand FromString(String brandString)
        {
            Brand result;
            return Enum.TryParse(brandString, true, out result) ? result : Brand.None;
        }

        public static String Name(this Brand brand)
        {
            return Enum.GetName(typeof(Brand), brand);
        }
    }
}
