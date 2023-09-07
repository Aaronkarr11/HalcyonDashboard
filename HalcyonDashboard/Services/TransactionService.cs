using HalcyonDashboard.Controllers;
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

        public TransactionService(HttpClient client, ILogger<TransactionService> logger, IOptions<ApplicationSettings> settings)
        {
            _client = client;
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task<DashBoard> GetWorkTaskPercentages()
        {
            try
            {
                WorkTaskModel model = new WorkTaskModel();
                model.DeviceName = _settings.AzureSettings.Name;
                string content = JsonConvert.SerializeObject(model);

                string uri = _settings.AzureSettings.DashBoardDataURI;
                var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
                var res = _client.PostAsync(uri, stringContent).Result.Content.ReadAsStringAsync().Result;

                //var filteredResult = Newtonsoft.Json.JsonConvert.DeserializeObject<DashBoard>(rawResponse);
                var data = JsonConvert.DeserializeObject<DashBoard>(res);
                return data;
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
