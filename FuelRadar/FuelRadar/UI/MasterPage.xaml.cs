using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FuelRadar.UI
{
    /// <summary>
    /// The navigation drawer page
    /// </summary>
    public partial class MasterPage : ContentPage
    {
        public event EventHandler<DetailPageItem> DetailPageChanged;

        public List<DetailPageItem> NavigationItems { get; private set; }

        public MasterPage(List<DetailPageItem> detailPages)
        {
            this.NavigationItems = detailPages;
            // No explicit view model (only few bindings)
            this.BindingContext = this;
            this.InitializeComponent();
        }

        private void OnItemSelected(Object sender, SelectedItemChangedEventArgs args)
        {
            // Disable item selection
            (sender as ListView).SelectedItem = null;
        }

        private void OnItemTapped(Object sender, ItemTappedEventArgs args)
        {
            // Call event to change detail page on item taps
            this.DetailPageChanged?.Invoke(this, args.Item as DetailPageItem);
        }

    }
}
