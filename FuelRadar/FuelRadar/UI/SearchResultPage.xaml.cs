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
                List<PriceInfo> results = (sender as SearchResultVM).Results;
                // set station pins
                IEnumerable<Pin> pins = results.Select(
                    result => new Pin() {
                        Position = result.GasStation.Location.ToPosition(),
                        Type = PinType.SearchResult,
                        Label = result.GasStation.Name });
                foreach (Pin pin in pins)
                {
                    this.ResultMap.Pins.Add(pin);
                }
                // get map position
                double maxLat = results.Max(result => result.GasStation.Location.Latitude);
                double minLat = results.Min(result => result.GasStation.Location.Latitude);
                double maxLong = results.Max(result => result.GasStation.Location.Longitude);
                double minLong = results.Min(result => result.GasStation.Location.Longitude);
                Position center = new Position((minLat + maxLat) / 2, (minLong + maxLong) / 2);
                MapSpan mapArea = new MapSpan(center, (maxLat - minLat) * 1.1, (maxLong - minLong) * 1.1);
                this.ResultMap.MoveToRegion(mapArea);
            }
        }
    }
}
