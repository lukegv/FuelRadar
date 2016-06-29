using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using PropertyChanged;

using FuelRadar.Data;
using FuelRadar.Model;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class StatisticsVM
    {
        public int AverageSelectedDowIndex { get; set; }

        public DayOfWeek? AverageSelectedDow
        {
            get
            {
                if (this.AverageSelectedDowIndex == 0) return null;
                return (DayOfWeek)(this.AverageSelectedDowIndex - 1);
            }
        }

        public int AverageSelectedFuelTypeIndex { get; set; }

        public FuelType AverageSelectedFuelType
        {
            get
            {
                return (FuelType)(this.AverageSelectedFuelTypeIndex);
            }
        }

        public PlotModel AverageModel
        {
            get
            {
                this.averageModel.Series.Clear();
                this.averageModel.Series.Add(this.AverageSeries);
                return averageModel;
            }
        }

        public Series AverageSeries
        {
            get
            {
                ColumnSeries series = new ColumnSeries() { FillColor = OxyColors.Red };
                series.Items.AddRange(
                    DbDataProvider.Instance.GetAveragePrice(this.AverageSelectedFuelType, this.AverageSelectedDow)
                    .Select(val => new ColumnItem(val)));
                return series;
            }
        }

        public StatisticsVM()
        {
            this.AverageSelectedDowIndex = 0;
            this.AverageSelectedFuelTypeIndex = 0;
            this.initializeAverageModel();
        }

        private PlotModel averageModel;
        private Axis averageBottomAxis;
        private Axis averageLeftAxis;


        private void initializeAverageModel()
        {
            this.averageBottomAxis = new CategoryAxis() { Minimum = 0, Maximum = 23, Position = AxisPosition.Bottom, IsPanEnabled = false, IsZoomEnabled = false };
            this.averageLeftAxis = new LinearAxis() { Minimum = 0.90, Maximum = 1.80, Position = AxisPosition.Left, IsPanEnabled = false, IsZoomEnabled = false };
            this.averageModel = new PlotModel();
            this.averageModel.Axes.Add(this.averageBottomAxis);
            this.averageModel.Axes.Add(this.averageLeftAxis);
        }
    }
}
