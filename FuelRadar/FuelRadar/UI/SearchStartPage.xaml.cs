using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FuelRadar.UI
{
    public partial class SearchStartPage : ContentPage
    {

        public SearchStartPage(object dataContext)
        {
            this.BindingContext = dataContext;
            this.InitializeComponent();
        }
    }
}
