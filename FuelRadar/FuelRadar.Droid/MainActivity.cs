using Android.App;
using Android.Content.PM;
using Android.OS;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using FuelRadar.UI;

namespace FuelRadar.Droid
{
    [Activity(Label = "Fuel Radar", Theme = "@android:style/Theme.Holo.Light", Icon = "@drawable/fuelRadar", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            this.LoadApplication(new RootApplication());
        }
    }
}

