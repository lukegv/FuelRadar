using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    public enum FuelType
    {
        Diesel = 0,
        Super = 1,
        E10 = 2
    }

    public static class FuelTypeHelpers
    {
        public static List<FuelType> GetList()
        {
            return Enum.GetValues(typeof(FuelType)).OfType<FuelType>().ToList();
        }

        public static String Name(this FuelType type)
        {
            return Enum.GetName(typeof(FuelType), type);
        }

        public static FuelType Next(this FuelType type)
        {
            return (FuelType)(((int)type + 1) % 3);
        }

        public static FuelType FromString(String fuelName)
        {
            switch (fuelName)
            {
                case "diesel":
                    return FuelType.Diesel;
                case "e5":
                    return FuelType.Super;
                case "e10":
                    return FuelType.E10;
                default:
                    throw new ArgumentException("Unknown fuel type");
            }
        }
    }
}
