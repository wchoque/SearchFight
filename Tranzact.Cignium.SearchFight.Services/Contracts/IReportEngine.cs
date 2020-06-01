using System;
using System.Collections.Generic;
using System.Text;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Contracts
{
    public interface IReportEngine
    {
        string Name { get;}
        int OrderPrint { get;}
        string GetReport(IList<SearchResponseDTO> searchResponse );
    }
}
