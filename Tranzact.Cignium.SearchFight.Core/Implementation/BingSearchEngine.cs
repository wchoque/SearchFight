using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Base;
using Tranzact.Cignium.SearchFight.Core.Config;
using Tranzact.Cignium.SearchFight.Core.Contracts;
using Tranzact.Cignium.SearchFight.Core.DTOs;

namespace Tranzact.Cignium.SearchFight.Core.Implementation
{
    /// <summary>
    /// Implements Bing search engine
    /// </summary>
    public class BingSearchEngine : ISearchEngine
    {
        #region properties
        public string Name => "Bing";
        private readonly HttpClient _client;
        private readonly BingConfig _bingConfig;
        #endregion

        public BingSearchEngine()
        {
            _bingConfig = new BingConfig(new AppConfig());
            _client = new HttpClient { DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", _bingConfig.ApiKey } } };
        }
        public BingSearchEngine(IAppConfig appConfig)
        {
            _bingConfig = new BingConfig(appConfig);
            _client = new HttpClient { DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", _bingConfig.ApiKey } } };
        }

        public async Task<long> GetTotalResultsAsync(string query)
        {
            if (string.IsNullOrEmpty(query)) 
                throw new ArgumentException("The specified parameter is invalid.", nameof(query));

            string searchRequest = _bingConfig.BaseUrl.Replace("{Query}", query);

            using var response = await _client.GetAsync(searchRequest);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Sorry, we are not able to process your request. Please try again later.");

            BingResponseDTO results = (await response.Content.ReadAsStringAsync()).MapTo<BingResponseDTO>();
            return results.WebPages.TotalEstimatedMatches;
        }
    }
}
