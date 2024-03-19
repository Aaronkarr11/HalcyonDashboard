using HalcyonDashboard.Models;
using HalcyonDashboard.Services;
using HalcyonCore.SharedEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Helpers = HalcyonDashboard.Services.Helpers;

namespace HalcyonDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationSettings _settings;

        public HomeController(ILogger<HomeController> logger, IOptions<ApplicationSettings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public async Task<IActionResult> IndexAsync([FromServices] ITransactionService transactionService)
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> Pie([FromServices] ITransactionService transactionService)
        {
            DashBoardData = null;
            DashBoardData = await transactionService.GetWorkTaskPercentages();

            var pieChartData = DashBoardData.percentageData;
            var model = new PieChartModel();
            model.PercentageComplete = pieChartData.percentCompleted.ToString() == "NaN" ? 0 : (int)pieChartData.percentCompleted;
            model.PercentageIncomplete = pieChartData.percentUnCompleted.ToString() == "NaN" ? 100 : (int)pieChartData.percentUnCompleted;



            ChartsViewModel viewModel = new ChartsViewModel();
            LineChartModel lineModel = new LineChartModel();
            lineModel = Helpers.BuildLineChartModel(DashBoardData.lineGraphModel);

            viewModel.lineChartModel = lineModel;
            viewModel.pieChartModel = model;

            return Json(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private DashBoard _dashBoard;

        public DashBoard? DashBoardData
        {
            get { return _dashBoard; }
            set { _dashBoard = value; }
        }

    }
}