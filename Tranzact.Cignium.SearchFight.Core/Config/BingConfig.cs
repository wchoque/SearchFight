namespace Tranzact.Cignium.SearchFight.Core.Config
{
    public class BingConfig
    {
        private readonly IAppConfig _appConfig;
        public BingConfig(IAppConfig appConfig) {
            _appConfig = appConfig;
        }
        public string BaseUrl => _appConfig.GetFromConfiguration("Bing.BaseUrl");
        public string ApiKey => _appConfig.GetFromConfiguration("Bing.ApiKey");
    }
}
