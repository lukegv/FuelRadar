using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FuelRadar.Model;

namespace FuelRadar.Data
{
    /// <summary>
    /// An interface for the database connection
    /// </summary>
    public interface IDataProvider
    {
        // Gas stations

        List<Station> GetFavouriteStations();

        int GetFavouriteStationCount();

        bool AddFavouriteStation(Station gasStation);

        void RemoveFavouriteStation(String gasStationId);

        bool IsFavorite(String gasStationId);

        // Prices

        void AddPriceToHistory(PriceInfo price);

        IEnumerable<AveragePriceResult> GetAveragePrice(FuelType type, DayOfWeek? dow);
    }
}
