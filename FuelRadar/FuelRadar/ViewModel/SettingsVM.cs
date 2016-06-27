using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

using GalaSoft.MvvmLight.Command;
using PropertyChanged;

using FuelRadar.Model;
using FuelRadar.Settings;
using FuelRadar.UI.Toast;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class SettingsVM
    {
        public int FuelTypeIndex { get; set; }

        public ICommand Save { get; set; }

        public SettingsVM()
        {
            this.FuelTypeIndex = (int)AppSettings.FuelType;
            this.Save = new RelayCommand(() => this.SaveSettings());
        }

        private void SaveSettings()
        {
            AppSettings.FuelType = (FuelType)this.FuelTypeIndex;
            CrossToast.ShowToast("Einstellungen gespeichert");
        }

    }
}
