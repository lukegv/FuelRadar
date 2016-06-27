using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using FuelRadar.Model;
using FuelRadar.ViewModel;

namespace FuelRadar.UI
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            // Violate MVVM due to missing binding property
            foreach (String value in FuelTypeHelpers.GetList().Select(fuelType => fuelType.Name()))
            {
                this.fuelTypePicker.Items.Add(value);
            }
            this.BindingContext = new SettingsVM();
        }
    }
}
