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
            if (DbDataProvider.Instance.GetFavouriteStationCount() > 0)
            {
                this.BindingContext = new FavoritesVM();
            }
            else
            {
                this.Children.Add(
                    new ContentPage() {
                       Content = new Grid()
                       {
                           Padding = 15,
                           Children =
                           {
                               new Label()
                               {
                                   Text = "You did not select any gas stations as favorite yet!",
                                   HorizontalOptions = LayoutOptions.Center,
                                   VerticalOptions = LayoutOptions.Center,
                                   FontSize = 20,
                                   HorizontalTextAlignment = TextAlignment.Center
                               }
                           }
                       }
                    }
                );
            }
            this.InitializeComponent();
        }
    }
}
