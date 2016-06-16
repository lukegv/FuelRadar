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
    public class HomeVM
    {
        public ICommand GoToSearch { get; set; }
        public ICommand GoToFavorites { get; set; }

        public HomeVM()
        {

        }
    }
}
