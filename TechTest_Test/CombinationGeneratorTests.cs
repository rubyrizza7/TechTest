using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechTest;

namespace TechTest_Tests
{
    [TestClass]
    public class CombinationGeneratorTests
    {
        [TestMethod]
        public void Create_InvalidRange_Throws()
        {
            // min value larger than max value
            Assert.ThrowsException<System.ArgumentException>(() => new ConcreteCombinationGenerator().GetAscendingCombination(2, 1, 1));
        }

        [TestMethod]
        public void Create_InvalidReturnSize_Throws()
        {
            // set combination length greater than range
            Assert.ThrowsException<System.ArgumentException>(() => new ConcreteCombinationGenerator().GetAscendingCombination(1, 10, 11));
        }

        [TestMethod]
        public void GetAcending_ReturnLengthEqualsCombinationLength()
        {
            int min = 1; int max = 10; int combinationLength = 5;

            var combination = new ConcreteCombinationGenerator().GetAscendingCombination(min, max, combinationLength);

            // assert returned length is as expected
            Assert.IsTrue(combination.Count == combinationLength);
        }

        [TestMethod]
        public void GetAcending_ContainRepetitions_False()
        {
            int min = -10; int max = 10; int combinationLength = 5;

            var combination = new ConcreteCombinationGenerator().GetAscendingCombination(min, max, combinationLength);

            // assert does not contain repetitions
            Assert.IsFalse(ContainsDuplicates(combination));
        }

        [TestMethod]
        public void GetAcending_IsSortedAcesdingOrder_True()
        {
            int min = 1; int max = 10; int combinationLength = 5;

            var combination = new ConcreteCombinationGenerator().GetAscendingCombination(min, max, combinationLength);

            // asserts does is sorted in acending order
            Assert.IsTrue(IsSortedAcending(combination));
        }

        [TestMethod]
        public void GetAscending_RangeBelowZero_ReturnAbsoluteValues()
        {
            int min = -10; int max = -1; int combinationLength = 5;

            var combination = new ConcreteCombinationGenerator().GetAscendingCombination(min, max, combinationLength);

            // assert does not contain negatives
            Assert.IsFalse(ContainsNegativeValue(combination));
        }

        [TestMethod]
        public void GetDescending_ReturnLengthEqualsCombinationLength()
        {
            int min = 1; int max = 10; int combinationLength = 5;

            var combination = new ConcreteCombinationGenerator().GetDescendingCombination(min, max, combinationLength);

            // assert returned length is as expected
            Assert.IsTrue(combination.Count == combinationLength);
        }

        [TestMethod]
        public void GetDescending_ContainRepetitions_False()
        {
            int min = 1; int max = 10; int combinationLength = 5;

            var combination = new ConcreteCombinationGenerator().GetDescendingCombination(min, max, combinationLength);

            // assert does not contain repetitions
            Assert.IsFalse(ContainsDuplicates(combination));
        }

        [TestMethod]
        public void GetDescending_IsSortedDecendingOrder_True()
        {
            int min = 1; int max = 10; int combinationLength = 5;

            var combination = new ConcreteCombinationGenerator().GetDescendingCombination(min, max, combinationLength);

            // asserts does is sorted in acending order
            Assert.IsTrue(IsSortedDescending(combination));
        }

        [TestMethod]
        public void GetDescending_RangeBelowZero_ReturnAbsoluteValues()
        {
            int min = -10; int max = -1; int combinationLength = 5;

            var combination = new ConcreteCombinationGenerator().GetDescendingCombination(min, max, combinationLength);

            // assert does not contain negatives
            Assert.IsFalse(ContainsNegativeValue(combination));
        }

        public bool IsSortedDescending(List<int> combination)
        {
            // check if element is less than  element to its right
            for (int i = 0; i < combination.Count - 1; i++)
            {
                if (combination[i] < combination[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private bool ContainsDuplicates(List<int> combination)
        {  
            // check if element is equal to element to its right
            for (int i = 0; i < combination.Count-1; i++)
            {
                if (combination[i] == combination[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        private bool ContainsNegativeValue(List<int> combination)
        {
            //check if element is equal to element to its right
            foreach (int number in combination)
            {
                if (number < 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsSortedAcending(List<int> combination)
        {
            // check if element is greater than to element to its right
            for (int i = 0; i < combination.Count-1; i++)
            {
                if (combination[i] > combination[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
