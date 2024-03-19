using HalcyonDashboard.Models;
using HalcyonCore.SharedEntities;

namespace HalcyonDashboard.Services
{
    public static class Helpers
    {

        public static LineChartModel BuildLineChartModel(this List<LineGraphModelItem> lineGraphModel)
        {
            var lineChartModel = new LineChartModel();
            foreach (var item in lineGraphModel)
            {
                switch (item.Name)
                {
                    case "Jan":
                        lineChartModel.JanAmount = item.TotalCompleted;
                        break;
                    case "Feb":
                        lineChartModel.FebAmount = item.TotalCompleted;
                        break;
                    case "Mar":
                        lineChartModel.MarchAmount = item.TotalCompleted;
                        break;
                    case "Apr":
                        lineChartModel.AprilAmount = item.TotalCompleted;
                        break;
                    case "May":
                        lineChartModel.MayAmount = item.TotalCompleted;
                        break;
                    case "Jun":
                        lineChartModel.JuneAmount = item.TotalCompleted;
                        break;
                    case "Jul":
                        lineChartModel.JulyAmount = item.TotalCompleted;
                        break;
                    case "Aug":
                        lineChartModel.AugAmount = item.TotalCompleted;
                        break;
                    case "Sep":
                        lineChartModel.SepAmount = item.TotalCompleted;
                        break;
                    case "Oct":
                        lineChartModel.OctAmount = item.TotalCompleted;
                        break;
                    case "Nov":
                        lineChartModel.NovAmount = item.TotalCompleted;
                        break;
                    case "Dec":
                        lineChartModel.DecAmount = item.TotalCompleted;
                        break;
                    default:
                        break;
                }
            }
            return lineChartModel;
        }

    }
}
