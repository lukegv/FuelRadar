
using Android.Widget;

using Xamarin.Forms;

using FuelRadar.UI.Toast;
using FuelRadar.Droid.UI.Toast;

[assembly: Dependency(typeof(AndroidToastNotifier))]
namespace FuelRadar.Droid.UI.Toast
{
    public class AndroidToastNotifier : IToastNotifier
    {
        public void ShowToast(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}