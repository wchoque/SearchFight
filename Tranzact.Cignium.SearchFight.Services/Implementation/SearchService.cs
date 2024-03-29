﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Core.Contracts;
using Tranzact.Cignium.SearchFight.Services.Contracts;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Implementation
{
    public class SearchService : ISearchService
    {
        #region Properties
        private readonly IList<ISearchEngine> _searchEngines;
        #endregion

        public SearchService() {
            _searchEngines = this.GetImplementedSearchEngines();
        }
        private IList<ISearchEngine> GetImplementedSearchEngines()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
               ?.Where(assembly => assembly.FullName.StartsWith("Tranzact.Cignium.SearchFight"))
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(ISearchEngine).ToString()) != null)
                .Select(type => (ISearchEngine)Activator.CreateInstance(type)).ToList();
        }

        public async Task<IList<SearchResponseDTO>> GetResults(IList<string> terms)
        {
            if (terms == null || !terms.Any()) {
                throw new ArgumentException("The specified argument is invalid.", nameof(terms));
            }

            IList<SearchResponseDTO> results = new List<SearchResponseDTO>();

            foreach (ISearchEngine engine in _searchEngines)
            {
                foreach (string term in terms)
                {
                    results.Add(new SearchResponseDTO
                    {
                        SearchEngineName = engine.Name,
                        Term = term,
                        TotalResults = await engine.GetTotalResultsAsync(term)
                    });
                }
            }
            return results;
        }
    }
}
