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
            this.LoadPrices = new RelayCommand(() => this.Load());
            this.Favorites = DbDataProvider.Instance.GetFavouriteStations()
                .Select(station => new PriceInfoVM(new PriceInfo(station), true)).ToList();
            //this.Load();
        }

        private async void Load()
        {
            this.IsLoadingPrices = true;
            IEnumerable<String> stationIds = this.Favorites.Select(vm => vm.RepresentedStation.ID);
            await Task.Delay(2000);
            this.IsLoadingPrices = false;
        }

    }
}
