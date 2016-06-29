using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

using FuelRadar.Model;

namespace FuelRadar.Data
{
    [Table("price_history")]
    public class HistoricalPriceData
    {
        [Column("id"), PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Column("timestamp")]
        public DateTime TimeStamp { get; set; }

        [Column("gasstation")]
        public String GasStationID { get; set; }
        [Column("latitude")]
        public double Latitude { get; set; }
        [Column("longitude")]
        public double Longitude { get; set; }

        [Column("diesel")]
        public double DieselPrice { get; set; }
        [Column("e5")]
        public double E5Price { get; set; }
        [Column("e10")]
        public double E10Price { get; set; }

        public HistoricalPriceData()
        {

        }

        public HistoricalPriceData(PriceInfo info)
        {
            this.TimeStamp = DateTime.Now;
            this.GasStationID = info.GasStation.ID;
            this.Latitude = info.GasStation.Location.Latitude;
            this.Longitude = info.GasStation.Location.Longitude;
            this.DieselPrice = info.CurrentPrice.Diesel;
            this.E5Price = info.CurrentPrice.E5;
            this.E10Price = info.CurrentPrice.E10;
        }
    }
}
