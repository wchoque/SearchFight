using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tranzact.Cignium.SearchFight.Services.Contracts;
using Tranzact.Cignium.SearchFight.Services.Implementation;

namespace SearchFight.Register
{
    public static class IOCRegister
    {
        /// <summary>
        /// Extension method to implement dependency injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            RegisterServices(services);
            RegisterOthers(services);
            return services;
        }

        /// <summary>
        /// Register interfaces and services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ISearchService, SearchService>();
            services.AddSingleton<IReportService, ReportService>();
            services.AddSingleton<ISearchFightService, SearchFightService>();
            return services;
        }

        private static IServiceCollection RegisterOthers(IServiceCollection services)
        {
            //services.AddTransient<IAppConfig, AppConfig>();
            return services;
        }
    }
}
