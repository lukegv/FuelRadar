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
    public partial class StatisticsPage : CarouselPage
    {
        public StatisticsPage()
        {
            this.InitializeComponent();
            foreach (String fuelTypeString in FuelTypeHelpers.GetList().Select(ft => ft.Name()))
            {
                this.averageFuelTypePicker.Items.Add(fuelTypeString);
            }
            this.averageDowPicker.Items.Add("Alle Tage");
            foreach (String dowString in DayOfWeekHelpers.GetList().Select(dow => dow.GermanName()))
            {
                this.averageDowPicker.Items.Add(dowString);
            }
            this.BindingContext = new StatisticsVM();
        }
    }
}
