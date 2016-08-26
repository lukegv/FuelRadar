using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

using FuelRadar.Model;

namespace FuelRadar.Data
{
    /// <summary>
    /// The price data structure for the database
    /// </summary>
    [Table(DbConstants.PriceHistoryTable)]
    public class HistoricalPriceData
    {
        [Column(DbConstants.PriceHistory.Id), PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Column(DbConstants.PriceHistory.Timestamp)]
        public DateTime TimeStamp { get; set; }

        [Column(DbConstants.PriceHistory.GasStation)]
        public String GasStationID { get; set; }
        [Column(DbConstants.PriceHistory.Latitude)]
        public double Latitude { get; set; }
        [Column(DbConstants.PriceHistory.Longitude)]
        public double Longitude { get; set; }

        [Column(DbConstants.PriceHistory.DieselPrice)]
        public double DieselPrice { get; set; }
        [Column(DbConstants.PriceHistory.E5Price)]
        public double E5Price { get; set; }
        [Column(DbConstants.PriceHistory.E10Price)]
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
