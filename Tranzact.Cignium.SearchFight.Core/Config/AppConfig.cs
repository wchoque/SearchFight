using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.IO;

namespace Tranzact.Cignium.SearchFight.Core.Config
{
    public class AppConfig : IAppConfig
    {
        private const string MISSING_CONFIGURATION = "There was an isue with the configuration file. (Missing Value: {Key})";
        private readonly IConfiguration _configuracion;
        public AppConfig() {
            _configuracion = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        }

        /// <summary>
        /// Get value from configuration file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetFromConfiguration(string key)
        {
            var value = _configuracion.GetSection("SearchEngineSettings")[key];

            if (string.IsNullOrEmpty(value))
                throw new ConfigurationErrorsException(MISSING_CONFIGURATION.Replace("{Key}", key));

            return value;
        }
    }
}
