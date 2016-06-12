using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using PropertyChanged;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    internal class SearchVM
    {
        public ICommand StartSearchFromCurrent { get; set; }
        public ICommand StartSearchFromAddress { get; set; }

        public String SearchStreet { get; set; }

        public String SearchTown { get; set; }

        public bool IsLoading { get; set; }

        public SearchVM()
        {
            this.SearchStreet = String.Empty;
            this.SearchTown = String.Empty;
            this.IsLoading = false;
        }


    }
}
