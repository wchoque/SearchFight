namespace Tranzact.Cignium.SearchFight.Core.Config
{
    public class GoogleConfig 
    {
        private readonly IAppConfig _appConfig;
        public GoogleConfig(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        public string BaseUrl => _appConfig.GetFromConfiguration("Google.BaseUrl");
        public string ApiKey => _appConfig.GetFromConfiguration("Google.ApiKey");
        public string ContextId => _appConfig.GetFromConfiguration("Google.ContextId");
    }
}
