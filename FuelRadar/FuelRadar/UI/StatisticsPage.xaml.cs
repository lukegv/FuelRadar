using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using FuelRadar.ViewModel;

namespace FuelRadar.UI
{
    public partial class StatisticsPage : CarouselPage
    {
        public StatisticsPage()
        {
            this.BindingContext = new StatisticsVM();
            this.InitializeComponent();
        }
    }
}
