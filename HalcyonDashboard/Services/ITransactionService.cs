using HalcyonSoft.SharedEntities;

namespace HalcyonDashboard.Services
{
    public interface ITransactionService
    {
        DashBoard DashBoardData { get; set; }

        Task<HttpResponseMessage> GetWorkTaskPercentages();
    }
}