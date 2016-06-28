using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using FuelRadar.Data;
using FuelRadar.ViewModel;


namespace FuelRadar.UI
{
    public partial class FavoritesPage : CarouselPage
    {

        public FavoritesPage()
        {
            this.BindingContext = new FavoritesVM();
            this.InitializeComponent();
            (this.BindingContext as FavoritesVM).Load();
        }
    }
}
