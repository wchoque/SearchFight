using Microsoft.Extensions.DependencyInjection;
using SearchFight.Register;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tranzact.Cignium.SearchFight.Services.Contracts;

namespace SearchFight
{
    class Program
    {
        /// <summary>
        /// The Main method is the entry point of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No terms were specified for the Search Fight. Please, try again with the search terms.");
                return;
            }
            MainAsync(args).GetAwaiter().GetResult();
            Console.Read();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task MainAsync(string[] args)
        {
            var services = new ServiceCollection();
            IOCRegister.AddRegistration(services);
            var provider = services.BuildServiceProvider();
            var searchFightService = provider.GetRequiredService<ISearchFightService>();
            await searchFightService.SearchFightAsync(args.ToList());
            searchFightService.GetReports().ForEach(report => Console.WriteLine(report.Result));
        }
    }
}
