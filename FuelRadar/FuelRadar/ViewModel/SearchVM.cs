using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelRadar.ViewModel
{
    
    internal class SearchVM
    {
        public String SearchTerm { get; set; }

        public SearchVM()
        {
            this.SearchTerm = String.Empty;
        }
    }
}
