using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;

using FuelRadar.Model;

namespace FuelRadar.Data
{
    public class DbDataProvider : IDataProvider
    {
        private static DbDataProvider singleton = null;
        public static DbDataProvider Instance
        {
            get
            {
                if (DbDataProvider.singleton == null) DbDataProvider.singleton = new DbDataProvider();
                return DbDataProvider.singleton;
            }
        }

        private Object DbLock;
        private SQLiteConnection DbConnection;

        private DbDataProvider()
        {
            this.DbLock = new Object();
            this.DbConnection = DependencyService.Get<ISqliteProvider>().GetConnection();
            this.DbConnection.CreateTable<FavouriteStationData>();
            this.DbConnection.CreateTable<HistoricalPriceData>();
        }

        public List<Station> GetFavouriteStations()
        {
            List<FavouriteStationData> queryResult;
            lock (this.DbLock)
            {
                queryResult = this.DbConnection.Table<FavouriteStationData>().ToList();
            }
            return queryResult.Select(favData => favData.ToStation()).ToList();
        }

        public int GetFavouriteStationCount()
        {
            lock (this.DbLock)
            {
                return this.DbConnection.Table<FavouriteStationData>().Count();
            }
        }

        public bool AddFavouriteStation(Station gasStation)
        {
            bool favoriteKicked = false;
            lock (this.DbLock)
            {
                int count = this.DbConnection.Table<FavouriteStationData>().Count();
                if (count == 10)
                {
                    this.DbConnection.Execute("DELETE FROM " + DbConstants.FavoriteStationsTable + " LIMIT 1");
                    favoriteKicked = true;
                }
                this.DbConnection.Insert(new FavouriteStationData(gasStation));
            }
            return favoriteKicked;
        }

        public void RemoveFavouriteStation(string gasStationId)
        {
            lock (this.DbLock)
            {
                this.DbConnection.Execute(
                    "DELETE FROM " + DbConstants.FavoriteStationsTable + 
                    " WHERE " + DbConstants.FavoriteStations.Id + " = '" + gasStationId + "'");
            }
        }

        public bool IsFavorite(string gasStationId)
        {
            lock (this.DbLock)
            {
                return this.DbConnection.ExecuteScalar<int>(
                    "SELECT count(*) FROM " + DbConstants.FavoriteStationsTable + 
                    " WHERE " + DbConstants.FavoriteStations.Id + " = '" + gasStationId + "'") > 0;
            }
        }

        public List<Price> GetAllHistoricalPrices()
        {
            lock (this.DbLock)
            {
                return null;
            }
        }

        public void AddPriceToHistory(Price price)
        {
            lock (this.DbLock)
            {
                
            }
        }

    }
}
