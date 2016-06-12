using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

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
        private SQLiteConnection DbConnection;

        private DbDataProvider()
        {
            this.DbLock = new Object();
        }

        public List<GasStationData> GetFavouriteStations()
        {
            throw new NotImplementedException();
        }

        public void AddFavouriteStation(GasStationData gasStation)
        {
            throw new NotImplementedException();
        }

        public void RemoveFavouriteStation(GasStationData gasStation)
        {
            throw new NotImplementedException();
        }

        public List<PriceData> GetAllHistoricalPriceData()
        {
            throw new NotImplementedException();
        }

        public void AddPriceDataToHistory(PriceData price)
        {
            throw new NotImplementedException();
        }
    }
}
