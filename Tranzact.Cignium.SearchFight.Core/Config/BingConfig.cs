﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tranzact.Cignium.SearchFight.Core.Config
{
    public class BingConfig : BaseConfig
    {
        public static string BaseUrl => GetFromConfiguration("Bing.BaseUrl");
        public static string ApiKey => GetFromConfiguration("Bing.ApiKey");
    }
}
