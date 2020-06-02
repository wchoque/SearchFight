using System;
using System.Collections.Generic;
using System.Linq;
using Tranzact.Cignium.SearchFight.Services.Contracts;
using Tranzact.Cignium.SearchFight.Services.DTOs;

namespace Tranzact.Cignium.SearchFight.Services.Implementation
{
    public class ReportService : IReportService
    {
        #region Properties
        public IList<Report> Reports { get; set; }
        private readonly IList<IReportEngine> ReportEngines;
        #endregion

        public ReportService() {
            ReportEngines = GetImplementedReportEngines();
            Reports = new List<Report>();
        }

        /// <summary>
        /// Get classes that implemented the interface IReportEngine
        /// </summary>
        /// <returns></returns>
        private IList<IReportEngine> GetImplementedReportEngines()
        {
            return AppDomain.CurrentDomain.GetAssemblies()?.Where(assembly => assembly.FullName.StartsWith("Tranzact.Cignium.SearchFight"))
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(typeof(IReportEngine).ToString()) != null)
                .Select(type => (IReportEngine) Activator.CreateInstance(type)).ToList();
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
