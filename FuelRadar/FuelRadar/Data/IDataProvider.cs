using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.Data
{
    public interface IDataProvider
    {
        // Gas stations

        List<GasStationData> GetFavouriteStations();

        void AddFavouriteStation(GasStationData gasStation);

        void RemoveFavouriteStation(GasStationData gasStation);

        // Prices

        List<PriceData> GetAllHistoricalPriceData();

        void AddPriceDataToHistory(PriceData price);
    }
}
