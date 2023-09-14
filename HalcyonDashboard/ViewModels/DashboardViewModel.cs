using CommunityToolkit.Mvvm.ComponentModel;
using HalcyonDashboard.Services;
using HalcyonSoft.Clients;
using HalcyonSoft.SharedEntities;
using LiveChartsCore;
using LiveChartsCore.Geo;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.VisualElements;
using Newtonsoft.Json;
using SkiaSharp;
using System.Net.Http;


namespace HalcyonDashboard.ViewModels
{
    public class DashboardViewModel : ObservableObject
    {
        private ITransactionService _transactionServices;
        public DashboardViewModel(ITransactionService transactionServices)
        {
            _transactionServices = transactionServices;

            var name = "Welcome!";

        }

        public async void OnAppearing()
        {
            try
            {
                PieGraphTitle = $"Work Tasks Overview for {DateTime.Now.Year}";
                BarGraphTitle = $"Comparison of Last Month & Current Month";
                var httpResponseMessage = await _transactionServices.GetWorkTaskPercentages();
                var response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                if (response == null)
                {
                    DashBoardData = new DashBoard();
                }
                else
                {
                    DashBoardData = JsonConvert.DeserializeObject<DashBoard>(response);
                }

                List<string> labels = new List<string>();

                foreach (var item in DashBoardData.lineGraphModel)
                {
                    labels.Add(item.Name);
                };

                List<LineGraphModelItem> lineGraphModels = new List<LineGraphModelItem>();
                lineGraphModels = DashBoardData.lineGraphModel;

                SuperSer = new ISeries[]
                 {
               new LineSeries<LineGraphModelItem>
            {
                    Values = lineGraphModels,
                    Mapping = (city, point) =>
                     {
                           point.Coordinate = new(city.TotalCompleted, city.TotalCompleted);
                      }
             }
                 };



            }
            catch (Exception ex)
            {

            }
        }


        public ISeries[] TestSeries { get; set; } =
        {
        new LineSeries<double>
        {
            Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
            Fill = null
        }
    };

        public LabelVisual TestTitle { get; set; } =
            new LabelVisual
            {
                Text = "My chart title",
                TextSize = 25,
                Padding = new LiveChartsCore.Drawing.Padding(15),
                Paint = new SolidColorPaint(SKColors.DarkSlateGray)
            };



        private DashBoard _dashboard;
        public DashBoard DashBoardData
        {
            get => _dashboard;
            set => SetProperty(ref _dashboard, value);
        }



        private string _pieGraphTitle;
        public string PieGraphTitle
        {
            get => _pieGraphTitle;
            set => SetProperty(ref _pieGraphTitle, value);
        }

        private string _barGraphTitle;
        public string BarGraphTitle
        {
            get => _barGraphTitle;
            set => SetProperty(ref _barGraphTitle, value);
        }

        private IEnumerable<ISeries> _series;
        public IEnumerable<ISeries> Series
        {
            get => _series;
            set => SetProperty(ref _series, value);
        }

        private IEnumerable<ISeries> _barSeries;
        public IEnumerable<ISeries> BarSeries
        {
            get => _barSeries;
            set => SetProperty(ref _barSeries, value);
        }

        private IEnumerable<ISeries> _barSeries2;
        public IEnumerable<ISeries> BarSeries2
        {
            get => _barSeries2;
            set => SetProperty(ref _barSeries2, value);
        }

        public ISeries[] SuperSer { get; set; }

        private ISeries[] _lineSeries;
        public ISeries[] SeriesCollection
        {
            get => _lineSeries;
            set => SetProperty(ref _lineSeries, value);
        }

        private List<Axis> _xaxes;
        public List<Axis> XAxes
        {
            get => _xaxes;
            set => SetProperty(ref _xaxes, value);
        }

        private List<Axis> _barXaxes;
        public List<Axis> BarXAxes
        {
            get => _barXaxes;
            set => SetProperty(ref _barXaxes, value);
        }

        private List<Axis> _barYaxes;
        public List<Axis> BarYAxes
        {
            get => _barYaxes;
            set => SetProperty(ref _barYaxes, value);
        }

        private List<Axis> _barXaxes2;
        public List<Axis> BarXAxes2
        {
            get => _barXaxes2;
            set => SetProperty(ref _barXaxes2, value);
        }

        private List<Axis> _barYaxes2;
        public List<Axis> BarYAxes2
        {
            get => _barYaxes2;
            set => SetProperty(ref _barYaxes2, value);
        }

        private List<Axis> _yaxes;
        public List<Axis> YAxes
        {
            get => _yaxes;
            set => SetProperty(ref _yaxes, value);
        }


        //public IEnumerable<ISeries> Series { get; set; }
    }
}
