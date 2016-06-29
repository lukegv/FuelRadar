using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OxyPlot;
using PropertyChanged;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class StatisticsVM
    {
        public PlotModel Model { get; set; }

        public StatisticsVM()
        {
            this.Model = new PlotModel() { Title = "Test" };
        }
    }
}
