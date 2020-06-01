using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Cignium.SearchFight.Core.Contracts
{
    public interface ISearchEngine
    {
        string Name { get; }
        Task<long> GetTotalResultsAsync(string query);
    }
}
