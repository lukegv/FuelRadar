using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FuelRadar.UI
{
    public class DetailPageItem
    {
        public String Title { get; private set; }
        public ImageSource IconSource { get; private set; }
        public Page Page { get; private set; }

        public DetailPageItem(String title, String iconRes, Page page)
        {
            this.Title = title;
            this.IconSource = ImageSource.FromResource(iconRes);
            this.Page = page;
        }
    }
}
