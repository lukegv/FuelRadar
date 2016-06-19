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
        private ContentPage emptyPage;
        private ContentPage EmptyPage
        {
            get
            {
                if (this.emptyPage == null) this.emptyPage = this.CreateEmptyPage();
                return this.emptyPage;
            }
        }

        public FavoritesPage()
        {
            if (DbDataProvider.Instance.GetFavouriteStationCount() > 0)
            {
                this.BindingContext = new FavoritesVM();
            }
            else
            {
                this.Children.Add(this.EmptyPage);
            }
            this.InitializeComponent();
        }

        public void Update()
        {
            if (DbDataProvider.Instance.GetFavouriteStationCount() > 0)
            {
                this.Children.Remove(this.EmptyPage);
                this.BindingContext = new FavoritesVM();
            }
            else
            {
                this.BindingContext = null;
                this.Children.Add(this.EmptyPage);
            }
        }

        private ContentPage CreateEmptyPage()
        {
            return new ContentPage()
            {
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
            };
        }
    }
}
