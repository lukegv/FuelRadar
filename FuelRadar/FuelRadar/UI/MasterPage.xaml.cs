using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FuelRadar.UI
{
    public partial class MasterPage : ContentPage
    {
        public event EventHandler<DetailPageItem> DetailPageChanged;

        public List<DetailPageItem> NavigationItems { get; private set; }

        public MasterPage(List<DetailPageItem> detailPages)
        {
            this.BindingContext = this;
            this.NavigationItems = detailPages;
            this.InitializeComponent();
        }

        private void OnItemSelected(Object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;
        }

        private void OnItemTapped(Object sender, ItemTappedEventArgs args)
        {
            this.DetailPageChanged?.Invoke(this, args.Item as DetailPageItem);
        }

    }
}
