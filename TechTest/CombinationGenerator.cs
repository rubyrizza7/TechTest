using System;
using System.Collections.Generic;
using System.Linq;

namespace TechTest
{
    public class CombinationGenerator
    {
        private readonly int returnSize;
        private readonly List<int> numberPool;
        private readonly Random rand;

        public CombinationGenerator(int minValue, int maxValue, int returnSize)
        {
            // check valid parameters
            if (maxValue < minValue)
            {
                throw new ArgumentException("max value must be greater than min value", nameof(maxValue) + ": " + maxValue + " " + nameof(minValue) + ": " + minValue);
            }else if (returnSize > maxValue - minValue)
            {
                throw new ArgumentException("return Size cannot be greater than range");
            }

            this.returnSize = returnSize;

            /*generate number pool with ABSOLUTE values. If there are both negative and positive number 
             * in the range using absolute values will cause dupliates in the pool.  Restrict the range to remove duplicates*/
             if (minValue < 0 && maxValue > 0)
            {
                if (Math.Abs(minValue) > Math.Abs(maxValue))
                {
                    maxValue = 0;
                }
                else
                {
                    minValue = 0;
                }
            }
     
            numberPool = new List<int>();
            for (int i = minValue; i <= maxValue; i++)
            {
                numberPool.Add(Math.Abs(i));
            }

            // initialise random
            rand = new Random();
        }


        private List<int> GetCombination()
        {
            // generate a combination by shuffling pool then taking first n integers
            return numberPool.OrderBy(a => rand.Next()).Take(returnSize).ToList();
        }

        public List<int> GetNewAscending()
        {
            var selectedNumbers = GetCombination();
            selectedNumbers.Sort();
            return selectedNumbers;
        }

        public List<int> GetNewDescending()
        {
            var selectedNumbers = GetCombination();
            selectedNumbers.Sort((a, b) => b.CompareTo(a));   // sort desending
            return selectedNumbers;
        }
    }
}
