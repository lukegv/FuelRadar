using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using PropertyChanged;
using GalaSoft.MvvmLight.Command;

using FuelRadar.Model;
using FuelRadar.Requests;

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

        public SearchStartVM()
        {
            this.AddressStreet = String.Empty;
            this.AddressTown = String.Empty;
            this.IsSearching = false;
            this.StartGps = new RelayCommand(() => this.RunGps());
            this.StartAddress = new RelayCommand(() => this.RunAddress());
        }

        public void SetSearchState(bool isSearching)
        {
            this.IsSearching = isSearching;
        }

        private async void RunGps()
        {
            this.SetSearchState(true);
            List<PriceInfo> results = await ApiRequests.RequestGasStations(new GlobalCoordinate(50.775346, 6.083887), 25);
            if (results.Count > 0)
            {
                this.ResultsFound?.Invoke(this, results);
            }
        }

        private async void RunAddress()
        {
            
        }

    }

}
