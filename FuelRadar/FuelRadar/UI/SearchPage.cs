using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace FuelRadar.UI
{
    public class SearchPage : NavigationPage
    {
        private SearchStartPage StartPage = new SearchStartPage();
        private SearchResultPage ResultPage = new SearchResultPage();

        public SearchPage() : base()
        {
            this.PushAsync(this.StartPage);
            this.PushAsync(this.ResultPage);
            
        }
    }
}
