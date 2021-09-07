using Microsoft.Extensions.DependencyInjection;
using System;

namespace TechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 1; int max = 10; int combinationLength = 5; int noCombinations = 5;

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IBulkCombinationsGenerator, BulkCombinationsGenerator>()
                .AddSingleton<ICombinationGenerator, ConcreteCombinationGenerator>()
                .BuildServiceProvider();

            //do the actual work here
            var generator = serviceProvider.GetService<IBulkCombinationsGenerator>();
            generator.PrintCombaintions(min, max, combinationLength, noCombinations);
        }
    }
}
