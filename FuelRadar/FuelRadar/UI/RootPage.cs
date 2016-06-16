﻿using System;
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
            this.MasterBehavior = MasterBehavior.Popover;

            this.DetailPageItems = new List<DetailPageItem>();
            this.DetailPageItems.Add(new DetailPageItem("Home", "FuelRadar.UI.Images.home.png", new HomePage()));
            this.DetailPageItems.Add(new DetailPageItem("Search", "FuelRadar.UI.Images.search.png", new SearchPage()));
            this.DetailPageItems.Add(new DetailPageItem("Favorites", "FuelRadar.UI.Images.favorites.png", new FavoritesPage()));

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
