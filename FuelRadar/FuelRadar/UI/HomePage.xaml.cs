using FuelRadar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FuelRadar.UI
{
    public partial class HomePage : ContentPage
    {
        public event EventHandler GoSearch;
        public event EventHandler GoFavorites;

        public HomePage()
        {
            HomeVM viewModel = new HomeVM();
            viewModel.GoSearch += RouteGoSearch;
            viewModel.GoFavorites += RouteGoFavorites;
            this.BindingContext = viewModel;
            this.InitializeComponent();
        }

        private void RouteGoSearch(object sender, EventArgs e)
        {
            this.GoSearch?.Invoke(this, e);
        }

        private void RouteGoFavorites(object sender, EventArgs e)
        {
            this.GoFavorites?.Invoke(this, e);
        }
    }
}
