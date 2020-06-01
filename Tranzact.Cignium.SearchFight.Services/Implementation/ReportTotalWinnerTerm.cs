using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tranzact.Cignium.SearchFight.Base;
using Tranzact.Cignium.SearchFight.Services.Contracts;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Implementation
{
    public class ReportTotalWinnerTerm : IReportEngine
    {
        #region Properties
        public string Name => "Total winner term";
        public int OrderPrint => 3;
        #endregion

        public ReportTotalWinnerTerm() { 

        }

        public string GetReport(IList<SearchResponseDTO> searchResponse)
        {
            if (searchResponse == null || !searchResponse.Any())
                throw new ArgumentException("The specified argument is invalid.", nameof(searchResponse));

            var termWinner = searchResponse.GetMax(item => item.TotalResults);
            return string.Concat("Total winner: ", termWinner.Term);
        }
    }
}
