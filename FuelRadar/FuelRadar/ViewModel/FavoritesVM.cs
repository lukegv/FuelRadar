using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;
using PropertyChanged;

using FuelRadar.Data;
using FuelRadar.Model;
using FuelRadar.Requests;
using FuelRadar.UI.Toast;

namespace FuelRadar.ViewModel
{
    /// <summary>
    /// The viewmodel for the favorites page
    /// </summary>
    [ImplementPropertyChanged]
    public class FavoritesVM
    {
        public int FavoriteCount { get; set; }

        public List<PriceInfoVM> Favorites { get; set; }

        public bool IsLoadingPrices { get; set; }

        public ICommand LoadPrices { get; set; }

        public FavoritesVM()
        {
            this.IsLoadingPrices = false;
            this.LoadPrices = new RelayCommand(() => this.Load());
            this.Favorites = new List<PriceInfoVM>();
            this.FavoriteCount = DbDataProvider.Instance.GetFavouriteStationCount();
            if (this.FavoriteCount > 0)
            {
                this.Favorites.AddRange(DbDataProvider.Instance.GetFavouriteStations()
                    .Select(station => new PriceInfoVM(new PriceInfo(station), true)));
            }
            else
            {
                // Provide a special page when there are no favorites saved
                // CarouselPage always needs at least on page as child
                this.Favorites.Add(new PriceInfoVM(new PriceInfo(new Station("", "", "", 0, 0))) { IsEmptyPage = true });
            }
        }

        public async void Load()
        {
            if (this.FavoriteCount > 0)
            {
                this.IsLoadingPrices = true;
                IEnumerable<String> stationIds = this.Favorites.Select(vm => vm.RepresentedStation.ID);
                Dictionary<String, Price> results = await ApiRequests.RequestPrices(stationIds);
                if (results != null)
                {
                    foreach (KeyValuePair<String, Price> result in results)
                    {
                        this.Favorites.First(fav => fav.RepresentedStation.ID == result.Key).RepresentedPrice = result.Value;
                    }
                }
                else
                {
                    CrossToast.ShowToast("Preisanfrage fehlgeschlagen");
                }
                this.IsLoadingPrices = false;
            }
        }

    }
}
