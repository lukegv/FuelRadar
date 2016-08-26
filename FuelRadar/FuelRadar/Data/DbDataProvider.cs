using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using Xamarin.Forms;

using FuelRadar.Model;
using System.Diagnostics;

namespace FuelRadar.Data
{
    /// <summary>
    /// The implementation of the database connection
    /// </summary>
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

        public void AddPriceToHistory(PriceInfo price)
        {
            lock (this.DbLock)
            {
                this.DbConnection.Insert(new HistoricalPriceData(price));
            }
        }

        public void AddPricesToHistory(IEnumerable<PriceInfo> prices)
        {
            lock (this.DbLock)
            {
                this.DbConnection.InsertAll(prices.Select(price => new HistoricalPriceData(price)));
            }
        }

        public IEnumerable<AveragePriceResult> GetAveragePrice(FuelType type, DayOfWeek? dow)
        {
            String dowClause = dow.HasValue ? " WHERE strftime('%w', " + DbConstants.PriceHistory.Timestamp + ") = '" + ((int)dow.Value).ToString() + "' " : String.Empty;
            lock (this.DbLock)
            {
                // not working, use dummy data instead :(
                //return this.DbConnection.Query<AveragePriceResult>(
                //    "SELECT avg(" + GetPriceConstantForFuelType(type) + ") AS AvgPrice, strftime('%H', " + DbConstants.PriceHistory.Timestamp + 
                //    ") AS Hour FROM " + DbConstants.PriceHistoryTable + dowClause + 
                //    " GROUP BY strftime('%H', " + DbConstants.PriceHistory.Timestamp + ")");
            }
            switch (type)
            {
                case FuelType.Diesel:
                    return new AveragePriceResult[]
                    {
                        new AveragePriceResult(1.109),
                        new AveragePriceResult(1.119),
                        new AveragePriceResult(1.119),
                        new AveragePriceResult(1.129),
                        new AveragePriceResult(1.119),
                        new AveragePriceResult(1.159),
                        new AveragePriceResult(1.169),
                        new AveragePriceResult(1.189),
                        new AveragePriceResult(1.169),
                        new AveragePriceResult(1.129),
                        new AveragePriceResult(1.109),
                        new AveragePriceResult(1.119),
                        new AveragePriceResult(1.119),
                        new AveragePriceResult(1.129),
                        new AveragePriceResult(1.119),
                        new AveragePriceResult(1.159),
                        new AveragePriceResult(1.169),
                        new AveragePriceResult(1.189),
                        new AveragePriceResult(1.169),
                        new AveragePriceResult(1.129),
                        new AveragePriceResult(1.159),
                        new AveragePriceResult(1.169),
                        new AveragePriceResult(1.189),
                        new AveragePriceResult(1.169),
                        new AveragePriceResult(1.129)
                    }.ToList();
                case FuelType.Super:
                    return new AveragePriceResult[]
                    {
                        new AveragePriceResult(1.309),
                        new AveragePriceResult(1.219),
                        new AveragePriceResult(1.319),
                        new AveragePriceResult(1.229),
                        new AveragePriceResult(1.219),
                        new AveragePriceResult(1.259),
                        new AveragePriceResult(1.269),
                        new AveragePriceResult(1.389),
                        new AveragePriceResult(1.269),
                        new AveragePriceResult(1.229),
                        new AveragePriceResult(1.309),
                        new AveragePriceResult(1.319),
                        new AveragePriceResult(1.319),
                        new AveragePriceResult(1.329),
                        new AveragePriceResult(1.319),
                        new AveragePriceResult(1.359),
                        new AveragePriceResult(1.369),
                        new AveragePriceResult(1.489),
                        new AveragePriceResult(1.369),
                        new AveragePriceResult(1.229),
                        new AveragePriceResult(1.359),
                        new AveragePriceResult(1.469),
                        new AveragePriceResult(1.389),
                        new AveragePriceResult(1.269),
                        new AveragePriceResult(1.329)
                    }.ToList();
                case FuelType.E10:
                    return new AveragePriceResult[]
                    {
                        new AveragePriceResult(1.209),
                        new AveragePriceResult(1.219),
                        new AveragePriceResult(1.219),
                        new AveragePriceResult(1.229),
                        new AveragePriceResult(1.219),
                        new AveragePriceResult(1.259),
                        new AveragePriceResult(1.269),
                        new AveragePriceResult(1.289),
                        new AveragePriceResult(1.269),
                        new AveragePriceResult(1.229),
                        new AveragePriceResult(1.209),
                        new AveragePriceResult(1.219),
                        new AveragePriceResult(1.219),
                        new AveragePriceResult(1.229),
                        new AveragePriceResult(1.219),
                        new AveragePriceResult(1.259),
                        new AveragePriceResult(1.269),
                        new AveragePriceResult(1.289),
                        new AveragePriceResult(1.269),
                        new AveragePriceResult(1.229),
                        new AveragePriceResult(1.359),
                        new AveragePriceResult(1.269),
                        new AveragePriceResult(1.289),
                        new AveragePriceResult(1.269),
                        new AveragePriceResult(1.329)
                    }.ToList();
                default:
                    throw new ArgumentException("Unknown fuel type");
            }
        }

        private static String GetPriceConstantForFuelType(FuelType type)
        {
            switch (type)
            {
                case FuelType.Diesel:
                    return DbConstants.PriceHistory.DieselPrice;
                case FuelType.Super:
                    return DbConstants.PriceHistory.E5Price;
                case FuelType.E10:
                    return DbConstants.PriceHistory.E10Price;
                default:
                    throw new ArgumentException("Unknown fuel type!");
            }
        }

    }
}
