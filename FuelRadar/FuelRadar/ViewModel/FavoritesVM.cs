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
    [ImplementPropertyChanged]
    public class FavoritesVM
    {
        public List<PriceInfoVM> Favorites { get; set; }

        public bool IsLoadingPrices { get; set; }

        public ICommand LoadPrices { get; set; }

        public FavoritesVM()
        {
            this.IsLoadingPrices = false;
            this.LoadPrices = new RelayCommand(() => this.Load());
            this.Favorites = DbDataProvider.Instance.GetFavouriteStations()
                .Select(station => new PriceInfoVM(new PriceInfo(station), true)).ToList();
        }

        public async void Load()
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
