using System;
using System.Collections.Generic;
using System.Text;

namespace Tranzact.Cignium.SearchFight.Core.Config
{
    public interface IAppConfig
    {
        /// <summary>
        /// Get value from a configuration file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetFromConfiguration(string key);
    }
}
