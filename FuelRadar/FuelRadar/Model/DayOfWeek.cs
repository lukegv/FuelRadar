using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Model
{
    // This uses the .NET DayOfWeek enumeration

    public static class DayOfWeekHelpers
    {
        public static String Name(this DayOfWeek dow)
        {
            return Enum.GetName(typeof(DayOfWeek), dow);
        }

        public static String GermanName(this DayOfWeek dow)
        {
            switch (dow)
            {
                case DayOfWeek.Sunday:
                    return "Sonntag";
                case DayOfWeek.Monday:
                    return "Montag";
                case DayOfWeek.Tuesday:
                    return "Dienstag";
                case DayOfWeek.Wednesday:
                    return "Mittwoch";
                case DayOfWeek.Thursday:
                    return "Donnerstag";
                case DayOfWeek.Friday:
                    return "Freitag";
                case DayOfWeek.Saturday:
                    return "Samstag";
                default:
                    throw new ArgumentException("Unknown day of week");
            }
        }

        public static IEnumerable<DayOfWeek> GetList()
        {
            return Enum.GetValues(typeof(DayOfWeek)).OfType<DayOfWeek>();
        }
    }
}
