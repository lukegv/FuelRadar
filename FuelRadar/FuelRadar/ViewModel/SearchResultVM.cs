using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PropertyChanged;

using FuelRadar.Model;


namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class SearchResultVM
    {
        public List<PriceInfo> Results { get; private set; }

        public SearchResultVM()
        {
            this.Results = new List<PriceInfo>();
        }

        public void UpdateResults(List<PriceInfo> newResults)
        {
            this.Results = newResults;
        }
    }
}
