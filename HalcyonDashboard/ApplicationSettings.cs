namespace HalcyonDashboard
{
    public class ApplicationSettings
    {
        public Logging Logging { get; set; }
        public Azuresettings AzureSettings { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Azuresettings
    {
        public string DashBoardDataURI { get; set; }
        public string Name { get; set; }
    }


}
