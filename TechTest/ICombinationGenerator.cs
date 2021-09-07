using System.Collections.Generic;

namespace TechTest
{
    public interface ICombinationGenerator
    {
        List<int> GetAscendingCombination(int minValue, int maxValue, int returnSize);
        List<int> GetDescendingCombination(int minValue, int maxValue, int returnSize);
        
    }
}