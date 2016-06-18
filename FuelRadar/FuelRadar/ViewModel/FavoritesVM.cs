using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PropertyChanged;

using FuelRadar.Model;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class FavoritesVM
    {
        public List<PriceInfo> Favorites { get; set; }

        public FavoritesVM()
        {
            this.Favorites = new List<PriceInfo>();
            this.Load();
        }

        private async void Load()
        {
            await Task.Delay(3000);
            
        }

    }
}
