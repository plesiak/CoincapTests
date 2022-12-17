using Microsoft.Extensions.Configuration;

namespace CoincapTask.Helpers
{
    public static class ConfigHelper
    {
        public static IConfigurationRoot Configuration;
        public static ConfigEntries ConfigEntries;

        static ConfigHelper()
        {

            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json");

            Configuration = configBuilder.Build();
            ConfigEntries = Configuration.GetSection("AppSettings").Get<ConfigEntries>();
        }
    }
}