using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Contracts
{
    public interface ISearchFightService
    {
        Task SearchFightAsync(IList<string> terms);
        List<Report> GetReports();
    }
}
