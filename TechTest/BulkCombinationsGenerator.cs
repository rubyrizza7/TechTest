using System;
using System.Collections.Generic;

namespace TechTest
{
    public class BulkCombinationsGenerator : IBulkCombinationsGenerator
    {

        private readonly ICombinationGenerator combinationGenerator;
       
        public BulkCombinationsGenerator(ICombinationGenerator service)
        {
            combinationGenerator = service;
        }

        public List<List<int>> GetCombinations(int minValue, int maxValue, int combinationLength, int noCombinations)
        {
            // check valid parameters
            if (noCombinations < 1)
            {
                throw new ArgumentException("must print atleast one combination");
            }


            // initialise
            List<List<int>> combinations = new List<List<int>>();

            // generate ascending combinations
            for (var i = 1; i <= noCombinations - 1; i++)
            {
                combinations.Add(combinationGenerator.GetAscendingCombination(minValue, maxValue, combinationLength));
            }

             // generate final descending combination
             combinations.Add(combinationGenerator.GetDescendingCombination(minValue, maxValue, combinationLength));
            

            return combinations;
        }


        public string GetCombinationsAsString(int minValue, int maxValue, int combinationLength, int noCombinations)
        {
            List<String> lines = new List<string>();

            foreach (List<int> combination in GetCombinations(minValue, maxValue, combinationLength, noCombinations))
            {
                lines.Add(string.Join(",", combination));
            }

            return string.Join("\n", lines);
        }

    }
}
