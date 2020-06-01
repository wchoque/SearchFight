﻿namespace Tranzact.Cignium.SearchFight.Core.Config
{
    public class GoogleConfig : BaseConfig
    {
        public static string BaseUrl => GetFromConfiguration("Google.BaseUrl");
        public static string ApiKey => GetFromConfiguration("Google.ApiKey");
        public static string ContextId => GetFromConfiguration("Google.ContextId");
    }
}
