using Android.App;
using Android.Content.PM;
using Android.OS;

using Xamarin;
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
            FormsMaps.Init(this, bundle);
            // Initialize the plot view
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();

            this.LoadApplication(new RootApplication());
        }
    }
}

