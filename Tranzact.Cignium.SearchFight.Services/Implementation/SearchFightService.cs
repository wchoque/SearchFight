using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Services.DTOs;
using Tranzact.Cignium.SearchFight.Services.Contracts;
using Tranzact.Cignium.SearchFight.Services.Implementation;

namespace Tranzact.Cignium.SearchFight.Services.Implementation
{
    public class SearchFightService : ISearchFightService
    {
        #region Attributes
        private List<Report> Reports { get; set; }
        #endregion
        #region Services
        private readonly ISearchService SearchService;
        private readonly IReportService ReportService;
        #endregion

        private SearchFightService() {
            Reports = new List<Report>();
        }

        /// <summary>
        /// </summary>
        /// <param name="searchService"></param>
        /// <param name="reportService"></param>
        /// <param name="winnerService"></param>
        public SearchFightService(ISearchService searchService, IReportService reportService)
        {
            SearchService = searchService;
            ReportService = reportService;
            Reports = new List<Report>();
        }

        public async Task SearchFightAsync(IList<string> terms) {
            IList<SearchResponseDTO> searchResponse = await SearchService.GetResults(terms);
            ReportService.GenerateReports(searchResponse);
            Reports.AddRange(ReportService.Reports.OrderBy(x => x.Order));
        }

        public List<Report> GetReports()
        {
            return Reports;
        }
    }
}
 