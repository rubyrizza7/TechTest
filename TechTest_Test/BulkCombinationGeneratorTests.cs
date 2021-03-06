using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTest;

namespace TechTest_Tests
{ 
    [TestClass]
    public class BulkCombinationGeneratorTests
    {

        private static Mock<ICombinationGenerator> comboGeneratorMock;


        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            comboGeneratorMock = new Mock<ICombinationGenerator>();
        }



        [TestMethod]
        public void Create_InvalidCombinationGeneratorParams_Throws()
        {
            // min value larger than max value
            int min = 10; int max = 1; int combinationLength = 5; int noCombinations = 5;

            comboGeneratorMock.Setup(p => p.GetAscendingCombination(min, max, combinationLength)).Throws(new ArgumentException());
            
            Assert.ThrowsException<System.ArgumentException>(() => new BulkCombinationsGenerator(comboGeneratorMock.Object).GetCombinations(min, max, combinationLength, noCombinations));
        }

        

        [TestMethod]
        public void Create_InvalidNoCombinations_Throws()
        {
            // set no combinations to 0
            int min = 1; int max = 10; int combinationLength = 5; int noCombinations = 0;
            Assert.ThrowsException<System.ArgumentException>(() => new BulkCombinationsGenerator(comboGeneratorMock.Object).GetCombinations(min, max, combinationLength, noCombinations));
        }

        [TestMethod]
        public void GetCombinations_LengthOfListIsNoCombinations()
        {
            int min = 1; int max = 10; int combinationLength = 5; int noCombinations = 5;

            comboGeneratorMock.Setup(p => p.GetAscendingCombination(min, max, combinationLength)).Returns(() => new List<int> { 1, 2, 3 });
            comboGeneratorMock.Setup(p => p.GetDescendingCombination(min, max, combinationLength)).Returns(() => new List<int> { 3, 2, 1 });

            List<List<int>> combinations = new BulkCombinationsGenerator(comboGeneratorMock.Object).GetCombinations(min, max, combinationLength, noCombinations);
            Assert.AreEqual(noCombinations,combinations.Count);
        }


        [TestMethod]
        public void GetCombinations_OrderingAscendingApartFromLast()
        {
            int min = 1; int max = 10; int combinationLength = 5; int noCombinations = 5;

            comboGeneratorMock.Setup(p => p.GetAscendingCombination(min, max, combinationLength)).Returns(() => new List<int> { 1, 2, 3 });
            comboGeneratorMock.Setup(p => p.GetDescendingCombination(min, max, combinationLength)).Returns(() => new List<int> { 3, 2, 1 });

            List<List<int>> combinations = new BulkCombinationsGenerator(comboGeneratorMock.Object).GetCombinations(min, max, combinationLength, noCombinations);

            // use tests from other class
            CombinationGeneratorTests tests = new CombinationGeneratorTests();

            // all apart from last should be ascending order
            for (int i = 0; i < noCombinations-2; i++)
            {
                Assert.IsTrue(tests.IsSortedAcending(combinations[i]));
            }

            // last should be descending
            Assert.IsTrue(tests.IsSortedDescending(combinations[noCombinations-1]));

        }

        [TestMethod]
        public void GetCombinations_LastNotDecending()
        {
            int min = 1; int max = 10; int combinationLength = 5; int noCombinations = 5;

            comboGeneratorMock.Setup(p => p.GetAscendingCombination(min, max, combinationLength)).Returns(() => new List<int> { 1, 2, 3 });
            comboGeneratorMock.Setup(p => p.GetDescendingCombination(min, max, combinationLength)).Returns(() => new List<int> { 1, 2, 3});

            List<List<int>> combinations = new BulkCombinationsGenerator(comboGeneratorMock.Object).GetCombinations(min, max, combinationLength, noCombinations);

            // use tests from other class
            CombinationGeneratorTests tests = new CombinationGeneratorTests();

            // all apart from last should be ascending order
            for (int i = 0; i < noCombinations - 2; i++)
            {
                Assert.IsTrue(tests.IsSortedAcending(combinations[i]));
            }

            // last should be descending
            Assert.IsFalse(tests.IsSortedDescending(combinations[noCombinations - 1]));

        }


    }
}
