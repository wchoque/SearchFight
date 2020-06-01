using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tranzact.Cignium.SearchFight.Services.Contracts;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Implementation
{
    public class ReportService : IReportService
    {
        public IList<Report> Reports { get; set; }
        private IList<IReportEngine> ReportEngines;

        public ReportService() {
            ReportEngines = GetImplementedSearchEngines();
            Reports = new List<Report>();
        }

        private IList<IReportEngine> GetImplementedSearchEngines()
        {
            IEnumerable<Assembly> loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
               ?.Where(assembly => assembly.FullName.StartsWith("Tranzact.Cignium.SearchFight"));

            return loadedAssemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(IReportEngine).ToString()) != null)
                .Select(type => Activator.CreateInstance(type) as IReportEngine).ToList();
        }

        public void GenerateReports(IList<SearchResponseDTO> searchResponse)
        {
            foreach (var report in ReportEngines)
            {
                Reports.Add(new Report() { Name = report.Name, Result = report.GetReport(searchResponse) });
            }
        }

    }
}
