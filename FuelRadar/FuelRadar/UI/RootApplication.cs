using Xamarin.Forms;

namespace FuelRadar.UI
{
    public class RootApplication : Application
    {
        public RootApplication()
        {
            this.MainPage = new RootPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
