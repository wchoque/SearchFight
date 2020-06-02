using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tranzact.Cignium.SearchFight.Services.Contracts;
using Tranzact.Cignium.SearchFight.Services.DTOs;
using Tranzact.Cignium.SearchFight.Services.Implementation;

namespace Tranzact.Cignium.SearchFight.Tests.Services
{
    [TestFixture]
    public class ReportTermResultTest
    {
        #region Attributes

        private IReportEngine _reportEngine;

        #endregion

        #region Setup

        [SetUp]
        public void SetUp()
        {
            _reportEngine = new ReportTermResult();
        }

        #endregion

        #region Tests

        [Test]
        public void GetReport_Null_Parameter_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _reportEngine.GetReport(null));
        }

        [Test]
        public void GetReport_Empty_Parameter_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _reportEngine.GetReport(new List<SearchResponseDTO>()));
        }

        [Test]
        public void GetSearchResultsReport_Success()
        {
            string winnersReport = _reportEngine.GetReport(GetDummyData());
            Assert.NotNull(winnersReport);
            Assert.IsNotEmpty(winnersReport);
        }

        #endregion

        #region Helper methods

        private List<SearchResponseDTO> GetDummyData()
        {
            List<SearchResponseDTO> testData = new List<SearchResponseDTO>
            {
                new SearchResponseDTO { SearchEngineName = "Google", Term = ".NET", TotalResults = 987654321L },
                new SearchResponseDTO { SearchEngineName = "Bing", Term = ".NET", TotalResults = 876543219L },

                new SearchResponseDTO { SearchEngineName = "Google", Term = "C#", TotalResults = 765432198L },
                new SearchResponseDTO { SearchEngineName = "Bing", Term = "C#", TotalResults = 654321987L },

                new SearchResponseDTO { SearchEngineName = "Google", Term = "Java", TotalResults = 543219876L },
                new SearchResponseDTO { SearchEngineName = "Bing", Term = "Java", TotalResults = 432198765L },

                new SearchResponseDTO { SearchEngineName = "Google", Term = "Java script", TotalResults = 321987654L },
                new SearchResponseDTO { SearchEngineName = "Bing", Term = "Java script", TotalResults = 219876543L }

            };

            return testData;
        }

        #endregion

    }
}
