using System.Collections.Generic;

namespace TechTest
{
    public interface IBulkCombinationsGenerator
    {
        List<List<int>> GetCombinations(int minValue, int maxValue, int combinationLength, int noCombinations);
        void PrintCombaintions(int minValue, int maxValue, int combinationLength, int noCombinations);
    }
}