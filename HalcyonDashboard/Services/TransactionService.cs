using HalcyonSoft.SharedEntities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace HalcyonDashboard.Services
{
    public class TransactionService : ITransactionService
    {
        private static HttpClient _client { get; set; }
        private readonly ILogger<TransactionService> _logger;
        private readonly ApplicationSettings _settings;

        public TransactionService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetWorkTaskPercentages()
        {
            try
            {
                WorkTaskModel model = new WorkTaskModel();
                model.DeviceName = "Maya";
                string content = JsonConvert.SerializeObject(model);

                string uri = "https://halcyontransactions.azurewebsites.net/api/GetDashBoardData?code=2PL_pLnmNR5ZCBc1CGwYViF8h2EdPSRb8cTbQs86x8fjAzFuu6bKjA==";
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(uri, stringContent);
                return response;;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private DashBoard _dashBoardData;

        public DashBoard DashBoardData
        {
            get { return _dashBoardData; }
            set { _dashBoardData = value; }
        }
    }
}
