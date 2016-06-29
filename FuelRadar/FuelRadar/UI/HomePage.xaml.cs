using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;

using GalaSoft.MvvmLight.Command;

namespace FuelRadar.UI
{
    public partial class HomePage : ContentPage
    {
        public event EventHandler GoSearch;
        public event EventHandler GoFavorites;

        public ICommand GoToSearch { get; set; }
        public ICommand GoToFavorites { get; set; }

        public HomePage()
        {
            this.GoToSearch = new RelayCommand(() => this.GoSearch?.Invoke(this, null));
            this.GoToFavorites = new RelayCommand(() => this.GoFavorites?.Invoke(this, null));
            // No explicit view model (only few bindings)
            this.BindingContext = this;
            this.InitializeComponent();
        }
    }
}
