﻿using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Core.Config;
using Tranzact.Cignium.SearchFight.Core.Contracts;
using Tranzact.Cignium.SearchFight.Core.Implementation;

namespace Tranzact.Cignium.SearchFight.Tests.Core
{
    [TestFixture]
    public class GoogleSearchEngineTest
    {
        #region Attributes

        private ISearchEngine _searchEngine;
        private IAppConfig _appConfig;

        #endregion

        #region Setup

        [SetUp]
        public void SetUp()
        {
            _appConfig = new AppConfig();
            _searchEngine = new GoogleSearchEngine(_appConfig);
        }

        #endregion

        #region Tests

        [Test]
        public void GetResults_Null_Query_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(null));
        }

        [Test]
        public void GetResults_Empty_Query_ArgumentException()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(string.Empty));
        }

        [Test]
        public async Task GetResults_Success()
        {
            var result = await _searchEngine.GetTotalResultsAsync("java script");
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<long>(result);
        }

        #endregion
    }
}
