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
        public Type PageType { get; private set; }

        public DetailPageItem(String title, String iconRes, Type pageType)
        {
            this.Title = title;
            this.IconSource = ImageSource.FromResource(iconRes);
            this.PageType = pageType;
        }

        public Page CreatePage()
        {
            return (Page)Activator.CreateInstance(this.PageType);
        }
    }
}
