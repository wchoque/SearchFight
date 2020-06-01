using System.Collections.Generic;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Contracts
{
    public interface ISearchService
    {
        /// <summary>
        /// Get detailed results by term
        /// </summary>
        /// <param name="terms"></param>
        /// <returns></returns>
        Task<IList<SearchResponseDTO>> GetResults(IList<string> terms);
    }
}
