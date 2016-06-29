using Xamarin.Forms;

namespace FuelRadar.UI
{
    /// <summary>
    /// The entry point for the Xamarin Forms application
    /// </summary>
    public class RootApplication : Application
    {
        public RootApplication()
        {
            this.MainPage = new RootPage();
        }
    }
}
