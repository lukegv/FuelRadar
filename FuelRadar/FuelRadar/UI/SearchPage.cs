using Xamarin.Forms;

using FuelRadar.ViewModel;

namespace FuelRadar.UI
{
    public class SearchPage : NavigationPage
    {
        private SearchVM ViewModel;

        private SearchStartPage StartPage;
        private SearchResultPage ResultPage;

        public SearchPage() : base()
        {
            this.ViewModel = new SearchVM();
            this.StartPage = new SearchStartPage(this.ViewModel);
            this.ResultPage = new SearchResultPage(this.ViewModel);
            this.PushAsync(this.StartPage);
            this.PushAsync(this.ResultPage);
        }
    }
}
