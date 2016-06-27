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
            
            this.DetailPageItems = new List<DetailPageItem>();
            this.DetailPageItems.Add(new DetailPageItem("Start", "FuelRadar.UI.Images.home.png", new HomePage()));
            this.DetailPageItems.Add(new DetailPageItem("Suche", "FuelRadar.UI.Images.search.png", new SearchPage()));
            this.DetailPageItems.Add(new DetailPageItem("Favoriten", "FuelRadar.UI.Images.favorites.png", new FavoritesPage()));
            this.DetailPageItems.Add(new DetailPageItem("Statistiken", "FuelRadar.UI.Images.statistics.png", new StatisticsPage()));
            this.DetailPageItems.Add(new DetailPageItem("Einstellungen", "FuelRadar.UI.Images.settings.png", new SettingsPage()));
            this.DetailPageItems.Add(new DetailPageItem("Info", "FuelRadar.UI.Images.about.png", new AboutPage()));

            this.Master = new MasterPage(this.DetailPageItems);
            (this.Master as MasterPage).DetailPageChanged += OnDetailPageChanged;
            this.Detail = this.DetailPageItems[0].Page;
        }

        public void OnDetailPageChanged(object sender, DetailPageItem item)
        {
            this.Detail = item.Page;
            this.IsPresented = false;
        }
    }
}
