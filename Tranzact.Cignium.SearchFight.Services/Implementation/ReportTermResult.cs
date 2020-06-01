using System;
using System.Collections.Generic;
using System.Linq;
using Tranzact.Cignium.SearchFight.Services.Contracts;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Implementation
{
    public class ReportTermResult : IReportEngine
    {
        #region Properties
        public string Name { get => "Detail engine by term"; }
        public int OrderPrint { get => 1; }
        #endregion

        public string GetReport(IList<SearchResponseDTO> searchResponse)
        {
            if (searchResponse == null || !searchResponse.Any())
                throw new ArgumentException("The specified parameter is invalid ", nameof(searchResponse));

            var terms = searchResponse.GroupBy(item => item.Term)
                    .Select(group => $"{group.Key}: {string.Join(" ", group.Select(item => $"{item.SearchEngineName}: {item.TotalResults}"))}")
                    .ToList();
            return string.Join("\n", terms);
        }
    }
}
