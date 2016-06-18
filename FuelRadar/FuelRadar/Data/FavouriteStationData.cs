using System;

using SQLite;

using FuelRadar.Model;

namespace FuelRadar.Data
{
    [Table("favourite_stations")]
    public class FavouriteStationData
    {
        [Column("id"), Unique]
        public String ID { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("brand")]
        public int Brand { get; set; }

        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("longitude")]
        public double Longitude { get; set; }

        public FavouriteStationData()
        {

        }

        public FavouriteStationData(Station station)
        {
            this.ID = station.ID;
            this.Name = station.Name;
            this.Brand = (int)station.Brand;
            this.Latitude = station.Location.Latitude;
            this.Longitude = station.Location.Longitude;
        }

        public Station ToStation()
        {
            return new Station(this.ID, this.Name, this.Brand, this.Latitude, this.Longitude);
        }
    }
}
