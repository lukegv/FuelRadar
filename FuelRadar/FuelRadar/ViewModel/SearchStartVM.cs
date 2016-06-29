using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;
using PropertyChanged;

using FuelRadar.Geo;
using FuelRadar.Model;
using FuelRadar.Requests;
using FuelRadar.UI.Toast;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    internal class SearchStartVM
    {
        public event EventHandler<List<PriceInfo>> ResultsFound;

        public ICommand StartGps { get; set; }
        public ICommand StartAddress { get; set; }

        public String AddressStreet { get; set; }

        public String AddressTown { get; set; }

        public bool IsSearching { get; set; }

        public String SearchDescription { get; set; }

        public SearchStartVM()
        {
            this.AddressStreet = String.Empty;
            this.AddressTown = String.Empty;
            this.IsSearching = false;
            this.SearchDescription = String.Empty;
            this.StartGps = new RelayCommand(() => this.RunGps());
            this.StartAddress = new RelayCommand(() => this.RunAddress());
        }

        public void SetSearchState(bool isSearching)
        {
            if (!isSearching) this.SearchDescription = String.Empty;
            this.IsSearching = isSearching;
        }

        private async void RunGps()
        {
            this.SetSearchState(true);
            this.SearchDescription = "Bestimme aktuelle Position ...";
            GlobalCoordinate position = await GeoLocator.GetCurrentPosition();
            if (position == null)
            {
                this.SetSearchState(false);
                CrossToast.ShowToast("Positionsbestimmung fehlgeschlagen!");
                return;
            }
            this.SearchDescription = "Suche Tankstellen ...";
            List<PriceInfo> results = await ApiRequests.RequestGasStations(new GlobalCoordinate(position.Latitude, position.Longitude));
            if (results == null)
            {
                this.SetSearchState(false);
                CrossToast.ShowToast("Suche fehlgeschlagen!");
                return;
            }
            if (results.Count > 0)
            {
                this.ResultsFound?.Invoke(this, results);
                this.SearchDescription = String.Empty; // bug fix for small return delay
            }
            else
            {
                this.SetSearchState(false);
                CrossToast.ShowToast("Es wurden keine Tankstellen gefunden.");
            }
        }

        private async void RunAddress()
        {
            this.SetSearchState(true);
            this.SearchDescription = "Ermittle Position der Adresse ...";
            GlobalCoordinate position = await GeoCoder.GetPositionForAddress(this.AddressStreet + "\n" + this.AddressTown);
            if (position == null)
            {
                this.SetSearchState(false);
                CrossToast.ShowToast("Positionsermittlung fehlgeschlagen");
                return;
            }
            this.SearchDescription = "Suche Tankstellen ...";
            List<PriceInfo> results = await ApiRequests.RequestGasStations(position);
            if (results == null)
            {
                this.SetSearchState(false);
                CrossToast.ShowToast("Suche fehlgeschlagen!");
                return;
            }
            if (results.Count > 0)
            {
                this.ResultsFound?.Invoke(this, results);
                this.SearchDescription = String.Empty; // bug fix for small return delay
            }
            else
            {
                this.SetSearchState(false);
                CrossToast.ShowToast("Es wurden keine Tankstellen gefunden.");
            }
        }

    }

}
