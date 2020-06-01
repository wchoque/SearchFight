using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;

namespace Tranzact.Cignium.SearchFight.Core.Config
{
    public class BaseConfig
    {
        private const string MISSING_CONFIGURATION = "There was an isue with the configuration file. (Missing Value: {Key})";
        
        /// <summary>
        /// Get value from configuration file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetFromConfiguration(string key)
        {
           IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Path.Combine(AppContext.BaseDirectory))
             .AddJsonFile("appsettings.json", true, true)
             .Build();

            var configurationValue = config.GetSection("SearchEngineSettings")[key];

            if (string.IsNullOrEmpty(configurationValue))
                throw new ConfigurationErrorsException(MISSING_CONFIGURATION.Replace("{Key}", key));

            return configurationValue;
        }
    }
}
