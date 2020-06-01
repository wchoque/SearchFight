using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Base;
using Tranzact.Cignium.SearchFight.Core.Config;
using Tranzact.Cignium.SearchFight.Core.Contracts;
using Tranzact.Cignium.SearchFight.Core.Models.Google;

namespace Tranzact.Cignium.SearchFight.Core.Implementation
{
    public class GoogleSearchEngine : ISearchEngine
    {
        public string Name => "Google";
        private HttpClient _client { get; }
        public GoogleSearchEngine()
        {
            _client = new HttpClient();
        }
        public async Task<long> GetTotalResultsAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("The specified parameter is invalid.", nameof(query));

            string searchRequest = GoogleConfig.BaseUrl.Replace("{Key}", GoogleConfig.ApiKey)
                .Replace("{ContextId}", GoogleConfig.ContextId)
                .Replace("{Query}", query);

            using (var response = await _client.GetAsync(searchRequest))
            {
                if (!response.IsSuccessStatusCode)
                    throw new Exception("We weren't able to process your request. Please try again later.");
                var val = await response.Content.ReadAsStringAsync();
                GoogleResponseDTO results = (await response.Content.ReadAsStringAsync()).MapTo<GoogleResponseDTO>();
                return long.Parse(results.SearchInformation.TotalResults);
                //return results.SearchInformation.TotalResults;
            }
        }
    }
}
