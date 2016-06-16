using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

using FuelRadar.Model;

namespace FuelRadar.Data
{
    public class DbDataProvider : IDataProvider
    {
        private static DbDataProvider singleton = null;
        public static DbDataProvider Instance()
        {
            if (DbDataProvider.singleton == null) DbDataProvider.singleton = new DbDataProvider();
            return DbDataProvider.singleton;
        }

        private Object DbLock;
        private SQLiteConnection Connection;

        private DbDataProvider()
        {
            this.DbLock = new Object();
        }

        public List<Station> GetFavouriteStations()
        {
            throw new NotImplementedException();
        }

        public void AddFavouriteStation(Station gasStation)
        {
            throw new NotImplementedException();
        }

        public void RemoveFavouriteStation(string gasStationId)
        {
            throw new NotImplementedException();
        }

        public bool IsFavorite(string gasStationId)
        {
            throw new NotImplementedException();
        }

        public List<Price> GetAllHistoricalPrices()
        {
            throw new NotImplementedException();
        }

        public void AddPriceToHistory(Price price)
        {
            throw new NotImplementedException();
        }
    }
}
