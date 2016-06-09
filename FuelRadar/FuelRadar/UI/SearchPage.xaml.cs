using Xamarin.Forms;

using FuelRadar.ViewModel;

namespace FuelRadar.UI
{
    public partial class SearchPage : CarouselPage
    {
        public SearchPage()
        {
            this.BindingContext = new SearchVM();
            this.InitializeComponent();
        }
    }
}
