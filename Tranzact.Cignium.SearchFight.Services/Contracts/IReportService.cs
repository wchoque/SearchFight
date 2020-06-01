using System;
using System.Collections.Generic;
using System.Text;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Contracts
{
    public interface IReportService
    {
        public IList<Report> Reports { get; set; }
        void GenerateReports(IList<SearchResponseDTO> searchResponse);
    }
}
