using System;

namespace TechTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 1; int max = 10; int combinationLength = 5; int noCombinations = 5;

            new BulkCombinationsGenerator(min, max, combinationLength, noCombinations).Print();
        }
    }
}
