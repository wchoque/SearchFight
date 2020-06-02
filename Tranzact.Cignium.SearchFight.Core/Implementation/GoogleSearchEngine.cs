using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Base;
using Tranzact.Cignium.SearchFight.Core.Config;
using Tranzact.Cignium.SearchFight.Core.Contracts;
using Tranzact.Cignium.SearchFight.Core.DTOs;

namespace Tranzact.Cignium.SearchFight.Core.Implementation
{
    /// <summary>
    /// Implements google search engine
    /// </summary>
    public class GoogleSearchEngine : ISearchEngine
    {
        #region properties
        public string Name => "Google";
        private HttpClient _client { get; }
        private readonly GoogleConfig _googleConfig;
        #endregion
        public GoogleSearchEngine()
        {
            _googleConfig = new GoogleConfig(new AppConfig());
            _client = new HttpClient();
        }

        public GoogleSearchEngine(IAppConfig appConfig)
        {
            _googleConfig = new GoogleConfig(appConfig);
            _client = new HttpClient();
        }

        public async Task<long> GetTotalResultsAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("The specified parameter is invalid.", nameof(query));

            string searchRequest = _googleConfig.BaseUrl.Replace("{Key}", _googleConfig.ApiKey)
                .Replace("{ContextId}", _googleConfig.ContextId)
                .Replace("{Query}", query);

            using var response = await _client.GetAsync(searchRequest);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Sorry, we are not able to process your request. Please try again later.");

            GoogleResponseDTO results = (await response.Content.ReadAsStringAsync()).MapTo<GoogleResponseDTO>();
            return long.Parse(results.SearchInformation.TotalResults);
        }
    }
}
