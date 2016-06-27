using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

using FuelRadar.Model;
using FuelRadar.ViewModel;

namespace FuelRadar.UI
{
    public partial class SearchResultPage : TabbedPage
    {

        public SearchResultPage(INotifyPropertyChanged dataContext)
        {
            dataContext.PropertyChanged += OnDataContextPropertyChanged;
            this.BindingContext = dataContext;
            this.InitializeComponent();
        }

        private void OnDataContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Results")
            {
                List<PriceInfoVM> results = (sender as SearchResultVM).Results;
                // set station pins
                IEnumerable<Pin> pins = results.Select(
                    result => new Pin() {
                        Position = result.Location.ToMapsPosition(),
                        Type = PinType.SearchResult,
                        Label = result.Name });
                foreach (Pin pin in pins)
                {
                    this.ResultMap.Pins.Add(pin);
                }
                // get map position
                double maxLat = results.Max(result => result.Location.Latitude);
                double minLat = results.Min(result => result.Location.Latitude);
                double maxLong = results.Max(result => result.Location.Longitude);
                double minLong = results.Min(result => result.Location.Longitude);
                Position center = new Position((minLat + maxLat) / 2, (minLong + maxLong) / 2);
                MapSpan mapArea = new MapSpan(center, (maxLat - minLat) * 1.25, (maxLong - minLong) * 1.25);
                this.ResultMap.MoveToRegion(mapArea);
            }
        }
    }
}
