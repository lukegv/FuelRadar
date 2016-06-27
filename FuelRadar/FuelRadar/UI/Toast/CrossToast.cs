using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FuelRadar.UI.Toast
{
    public static class CrossToast
    {
        public static void ShowToast(String message)
        {
            // Calls the dependency service to show a toast on the used platform
            DependencyService.Get<IToastNotifier>().ShowToast(message);
        }
    }
}
