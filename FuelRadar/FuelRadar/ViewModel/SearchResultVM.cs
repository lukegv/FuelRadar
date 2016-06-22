using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PropertyChanged;

using FuelRadar.Model;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class SearchResultVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PriceInfoVM SelectedResult { get; set; }

        public List<PriceInfoVM> Results { get; set; }

        public SearchResultVM()
        {
            this.Results = new List<PriceInfoVM>();
        }

        public void UpdateResults(List<PriceInfo> newResults)
        {
            this.Results = newResults.Select(priceInfo => new PriceInfoVM(priceInfo)).OrderBy(vm => vm.MainPrice).ToList();
            this.SelectedResult = this.Results.First();
        }
    }
}
