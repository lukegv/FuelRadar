using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FuelRadar.UI
{
    public class RootPage : MasterDetailPage
    {
        private List<DetailPageItem> DetailPageItems;

        public RootPage()
        {
            // Define master behavior as slider
            // Important for Windows apps with different default behavior
            this.MasterBehavior = MasterBehavior.Popover;
            
            // Create a list of all detail pages
            this.DetailPageItems = new List<DetailPageItem>();
            this.DetailPageItems.Add(new DetailPageItem("Start", "FuelRadar.UI.Images.home.png", typeof(HomePage)));
            this.DetailPageItems.Add(new DetailPageItem("Suche", "FuelRadar.UI.Images.search.png", typeof(SearchPage)));
            this.DetailPageItems.Add(new DetailPageItem("Favoriten", "FuelRadar.UI.Images.favorites.png", typeof(FavoritesPage)));
            this.DetailPageItems.Add(new DetailPageItem("Statistiken", "FuelRadar.UI.Images.statistics.png", typeof(StatisticsPage)));
            this.DetailPageItems.Add(new DetailPageItem("Einstellungen", "FuelRadar.UI.Images.settings.png", typeof(SettingsPage)));
            this.DetailPageItems.Add(new DetailPageItem("Info", "FuelRadar.UI.Images.about.png", typeof(AboutPage)));

            this.Master = new MasterPage(this.DetailPageItems);
            (this.Master as MasterPage).DetailPageChanged += OnDetailPageChanged;
            // Create the first detail page
            HomePage startPage = new HomePage();
            startPage.GoSearch += OnGoSearch;
            startPage.GoFavorites += OnGoFavorites;
            this.Detail = startPage;
        }

        public void OnDetailPageChanged(object sender, DetailPageItem item)
        {
            this.Detail = item.CreatePage();
            HomePage homePage = this.Detail as HomePage;
            if (homePage != null)
            {
                homePage.GoSearch += OnGoSearch;
                homePage.GoFavorites += OnGoFavorites;
            }
            this.IsPresented = false;
        }

        private void OnGoSearch(object sender, EventArgs e)
        {
            this.Detail = new SearchPage();
        }

        private void OnGoFavorites(object sender, EventArgs e)
        {
            this.Detail = new FavoritesPage();
        }
    }
}
