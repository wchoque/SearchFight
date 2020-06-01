using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Contracts
{
    public interface ISearchService
    {
        Task<IList<SearchResponseDTO>> GetResults(IList<string> terms);
    }
}
