using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FuelRadar.UI
{
    /// <summary>
    /// Describes a page type shown in the navigation drawer
    /// </summary>
    public class DetailPageItem
    {
        /// <summary>
        /// The title of this page type
        /// </summary>
        public String Title { get; private set; }
        /// <summary>
        /// The icon of this page type
        /// </summary>
        public ImageSource IconSource { get; private set; }
        /// <summary>
        /// The class to instantiate for this page type
        /// </summary>
        public Type PageType { get; private set; }

        public DetailPageItem(String title, String iconRes, Type pageType)
        {
            this.Title = title;
            this.IconSource = ImageSource.FromResource(iconRes);
            this.PageType = pageType;
        }

        /// <summary>
        /// Instantiates a new page for this page type
        /// </summary>
        /// <returns>The page object</returns>
        public Page CreatePage()
        {
            return (Page)Activator.CreateInstance(this.PageType);
        }
    }
}
