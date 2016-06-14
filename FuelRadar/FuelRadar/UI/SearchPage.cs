using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using FuelRadar.Model;
using FuelRadar.ViewModel;

namespace FuelRadar.UI
{
    public class SearchPage : NavigationPage
    {
        private SearchStartVM StartViewModel;
        private SearchResultVM ResultViewModel;

        private SearchStartPage StartPage;
        private SearchResultPage ResultPage;

        public SearchPage() : base()
        {
            base.Popped += this.OnPop;
            this.StartViewModel = new SearchStartVM();
            this.StartViewModel.ResultsFound += this.OnResultsFound;
            this.StartPage = new SearchStartPage(this.StartViewModel);
            this.PushAsync(this.StartPage);
        }

        private void OnResultsFound(object sender, List<PriceInfo> results)
        {
            if (this.ResultViewModel == null) this.ResultViewModel = new SearchResultVM();
            if (this.ResultPage == null) this.ResultPage = new SearchResultPage(this.ResultViewModel);
            this.ResultViewModel.UpdateResults(results);
            this.PushAsync(this.ResultPage);
        }

        private void OnPop(object sender, NavigationEventArgs args)
        {
            if (args.Page == this.ResultPage)
            {
                this.StartViewModel.SetSearchState(false);
            }
        }
    }
}
