using System.Threading.Tasks;

namespace Tranzact.Cignium.SearchFight.Core.Contracts
{
    public interface ISearchEngine
    {
        /// <summary>
        /// Search engine name to identity
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get total result from implemented search engine.
        /// </summary>
        /// <param name="query">Search term for the searh engine.</param>
        /// <returns>Total result for the specified query on the search engine.</returns>
        Task<long> GetTotalResultsAsync(string query);
    }
}
