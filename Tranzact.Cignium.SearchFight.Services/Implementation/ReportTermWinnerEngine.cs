using System;
using System.Collections.Generic;
using System.Linq;
using Tranzact.Cignium.SearchFight.Base;
using Tranzact.Cignium.SearchFight.Services.Contracts;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Implementation
{
    public class ReportTermWinnerEngine : IReportEngine
    {
        #region Properties
        public string Name => "Detail engine by term"; 
        public int OrderPrint => 2;
        #endregion

        public string GetReport(IList<SearchResponseDTO> searchResponse)
        {
            if (searchResponse == null || !searchResponse.Any())
                throw new ArgumentException("The specified argument is invalid.", nameof(searchResponse));

            var searchEngines = searchResponse.GroupBy(data => data.SearchEngineName,
                result => result, (searchEngine, results) => new SearchEngineWinner
                {
                    EngineName = searchEngine,
                    Term = results.GetMax(item => item.TotalResults).Term
                });

            var termsWinnerByEngine = searchEngines.Select(x => string.Concat(x.EngineName, " winner : ", x.Term)).ToList();
            return string.Join("\n", termsWinnerByEngine);
        }
    }
}
