using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;
using PropertyChanged;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class HomeVM
    {
        public event EventHandler GoSearch;
        public event EventHandler GoFavorites;

        public ICommand GoToSearch { get; set; }
        public ICommand GoToFavorites { get; set; }

        public HomeVM()
        {
            this.GoToSearch = new RelayCommand(() => this.GoSearch?.Invoke(this, null));
            this.GoToFavorites = new RelayCommand(() => this.GoFavorites?.Invoke(this, null));
        }
    }
}
