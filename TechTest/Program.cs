using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

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
            string retrievedCombinations = generator.GetCombinationsAsString(min, max, combinationLength, noCombinations);

            // using sqlite
            /*
            using (var db = new CombinationsContext())
            {
                // Note: This sample requires the database to be created before running.
                Console.WriteLine($"Database path: {db.DbPath}.");

                // Create
                Console.WriteLine("Inserting a new result");
                db.Add(new Result { combinations = retrievedCombinations });
                db.SaveChanges();

                // Read
                Console.WriteLine("Reading all results in table");
                var results = db.Results
                    .OrderBy(b => b.resultId);

                foreach (var result in results)
                {
                    Console.WriteLine("\nID:" +  result.resultId + "\nCombinations:\n" + result.combinations);
                }

            }*/


            //Use In Memory
            
            var options = new DbContextOptionsBuilder<CombinationsContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

            using (var context = new CombinationsContext(options))
            {
                Console.WriteLine("Before adding to table count = " + context.Results.Count());

                var customer = new Result
                {
                    combinations = retrievedCombinations
                };

                context.Results.Add(customer);
                context.SaveChanges();

                Console.WriteLine("After adding to table count = " + context.Results.Count());
                Console.WriteLine("Retrieved Results Content:");
                foreach (var result in context.Results)
                {
                    Console.WriteLine(result.combinations);
                }

            }

        }
    }
}
