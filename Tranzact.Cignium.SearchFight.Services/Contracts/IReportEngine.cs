using System.Collections.Generic;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Contracts
{
    public interface IReportEngine
    {
        /// <summary>
        /// Report name to identify
        /// </summary>
        string Name { get;}

        /// <summary>
        /// Order in which it will be displayed
        /// </summary>
        int OrderPrint { get;}

        /// <summary>
        /// Get the report result
        /// </summary>
        /// <param name="searchResponse"></param>
        /// <returns>Result as text</returns>
        string GetReport(IList<SearchResponseDTO> searchResponse );
    }
}
