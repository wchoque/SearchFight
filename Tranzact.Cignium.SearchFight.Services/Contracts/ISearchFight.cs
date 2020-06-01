using System.Collections.Generic;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Contracts
{
    public interface ISearchFightService
    {
        /// <summary>
        /// Run query search by implemented search engines
        /// </summary>
        /// <param name="terms"></param>
        /// <returns></returns>
        Task SearchFightAsync(IList<string> terms);

        /// <summary>
        /// Get the result of all implemented reports
        /// </summary>
        /// <returns></returns>
        List<Report> GetReports();
    }
}
