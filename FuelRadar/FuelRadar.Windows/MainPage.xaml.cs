using FuelRadar.UI;

namespace FuelRadar.Windows
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.LoadApplication(new RootApplication());
        }
    }
}
