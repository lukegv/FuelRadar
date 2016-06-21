using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using PropertyChanged;

using FuelRadar.Data;
using FuelRadar.Model;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class FavoritesVM
    {
        public ICommand LoadPrices { get; set; }

        public ObservableCollection<PriceInfoVM> Favorites { get; set; }

        public FavoritesVM()
        {
            this.Favorites = new ObservableCollection<PriceInfoVM>(
                DbDataProvider.Instance.GetFavouriteStations().Select(station => new PriceInfoVM(new PriceInfo(station, null))));
            this.Load();
        }

        private async void Load()
        {
            
        }

    }
}
