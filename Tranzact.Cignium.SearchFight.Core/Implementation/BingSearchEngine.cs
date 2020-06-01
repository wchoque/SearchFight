using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Base;
using Tranzact.Cignium.SearchFight.Core.Config;
using Tranzact.Cignium.SearchFight.Core.Contracts;
using Tranzact.Cignium.SearchFight.Core.Models.Bing;

namespace Tranzact.Cignium.SearchFight.Core.Implementation
{
    public class BingSearchEngine : ISearchEngine
    {
        public string Name => "Bing";
        private HttpClient _client { get; }
        public BingSearchEngine()
        {
            _client = new HttpClient { DefaultRequestHeaders = { { "Ocp-Apim-Subscription-Key", BingConfig.ApiKey } } };
        }

        public async Task<long> GetTotalResultsAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("The specified parameter is invalid.", nameof(query));

            string searchRequest = BingConfig.BaseUrl.Replace("{Query}", query);

            using (var response = await _client.GetAsync(searchRequest))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("We weren't able to process your request. Please try again later.");

                var data = await response.Content.ReadAsStringAsync();

                BingResponseDTO results = (await response.Content.ReadAsStringAsync()).MapTo<BingResponseDTO>();
                //return long.Parse(results.WebPages.TotalEstimatedMatches);
                return results.WebPages.TotalEstimatedMatches;
            }
        }
    }
}
