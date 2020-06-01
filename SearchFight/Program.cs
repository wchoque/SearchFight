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
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No terms were specified for the Search Fight. Please execute again with the search terms.");
                return;
            }
            //Console.WriteLine("Executing Search Fight....");
            //Console.WriteLine("Type words you want to compare");
            //var searchableWords = Console.ReadLine();
            //args = searchableWords.Split(" ");
            MainAsync(args).GetAwaiter().GetResult();
            Console.Read();
        }
        static async Task MainAsync(string[] args)
        {
            var services = new ServiceCollection();
            IOCRegister.AddRegistration(services);
            var provider = services.BuildServiceProvider();
            var searchFightService = provider.GetRequiredService<ISearchFightService>();
            await searchFightService.SearchFightAsync(args.ToList());
            searchFightService.GetReports().ForEach(report => Console.WriteLine(report.Result));
            //Console.WriteLine(SearchFightService.GetCompleteReports());
            //searchFightService.PrintCompleteReports();
        }
    }
}
