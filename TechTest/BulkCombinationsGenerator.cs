using System;
using System.Collections.Generic;

namespace TechTest
{
    public class BulkCombinationsGenerator
    { 
        private readonly CombinationGenerator combinationGenerator;
        private readonly int noCombinations;
        private List<List<int>> combinations;

        public BulkCombinationsGenerator(int minValue, int maxValue, int combinationLength, int noCombinations)
        {
            // check valid parameters
            if (noCombinations < 1)
            {
                throw new ArgumentException("must print atleast one combination");
            }


            // initialise
            this.noCombinations = noCombinations;
            combinations = new List<List<int>>();

            // create a combination generator
            combinationGenerator = new CombinationGenerator(minValue, maxValue, combinationLength);

            // generate ascending combinations
            for (var i = 1; i <= noCombinations - 1; i++)
            {
                combinations.Add(combinationGenerator.GetNewAscending());
            }

            // generate final descending combination
            combinations.Add(combinationGenerator.GetNewDescending());

        }

        public List<List<int>> GetCombinations()
        { 
            return combinations;
        }
        public void Print()
        {
            foreach (List<int> combination in combinations)
            {
                Console.WriteLine(string.Join(",", combination));
            }
        }

    }
}
