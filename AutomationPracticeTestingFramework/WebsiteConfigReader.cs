using System.Configuration;

namespace AutomationPracticeTestingFramework
{
    public class WebsiteConfigReader
    {
        public static readonly string HomeUrl = ConfigurationManager.AppSettings["home_url"];
        public static readonly string FadedTshirtUrl = ConfigurationManager.AppSettings["faded_tshirt_url"];
    }
}