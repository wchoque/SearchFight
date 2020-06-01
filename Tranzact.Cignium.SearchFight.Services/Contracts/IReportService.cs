using System.Collections.Generic;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Contracts
{
    public interface IReportService
    {
        /// <summary>
        /// Stores all results reports
        /// </summary>
        public IList<Report> Reports { get; set; }

        /// <summary>
        /// Generate all implemented reports
        /// </summary>
        /// <param name="searchResponse"></param>
        void GenerateReports(IList<SearchResponseDTO> searchResponse);
    }
}
