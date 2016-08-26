using System;

using SQLite;

using FuelRadar.Model;

namespace FuelRadar.Data
{
    /// <summary>
    /// The favourite gas station data structure for the database 
    /// </summary>
    [Table(DbConstants.FavoriteStationsTable)]
    public class FavouriteStationData
    {
        [Column(DbConstants.FavoriteStations.Id), Unique]
        public String ID { get; set; }

        [Column(DbConstants.FavoriteStations.Name)]
        public String Name { get; set; }

        [Column(DbConstants.FavoriteStations.Brand)]
        public int Brand { get; set; }

        [Column(DbConstants.FavoriteStations.Latitude)]
        public double Latitude { get; set; }

        [Column(DbConstants.FavoriteStations.Longitude)]
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
