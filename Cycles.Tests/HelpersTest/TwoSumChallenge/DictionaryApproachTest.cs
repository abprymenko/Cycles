using Cycles.LeetCodeTasks.TwoSumChallenge;
using System.Diagnostics;

namespace Cycles.Tests.HelpersTest.TwoSumChallenge
{
    #region DictionaryApproachTest
    /* TASK
     * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
     * You may assume that each input would have exactly one solution, and you may not use the same element twice.
     * You can return the answer in any order.
     */
    internal class DictionaryApproachTest
    {
        #region Private : Fields
        private static readonly int[,] TwoSumNumbersArgument = 
        {
            { -2, 0 },
            { -2, -1 },
            { -2, 2 },
            { -2, -3 },
            { -2, 1 },
            { 0, 1 },
            { 0, -2 },
            { 0, 1 },
            { 0, 0 },
            { 0, 5 },
            { 1, 4 },
            { 1, 1 },
            { 1, 2 },
            { 1, -1 },
            { 1, 1 },
            { 1, -3 },
            { 7, 1 },
            { 7, 5 },
            { 7, 4 },
            { 7, 2 },
            { 7, 3 },
            { 9, 5 },
            { 9, 3 },
            { 9, 2 },
            { 9, 4 },
            { 9, 1 },
            { 10, 5 },
            { 10, 4 },
            { 10, 9 },
            { 10, 7 },
            { 10, 8 },
            { 10, 10 }
        };
        private readonly int[,] _expected = 
        { 
            { 3, 4 },
            { -1, -1 },
            { 2, 3 },
            { 1, 3 }, 
            { 0, 3 }, 
            { -1, -1 }
        };
        private int _expectedCount = -1;
        #endregion

        #region Setup
        [SetUp]
        public void Setup()
        {
            _expectedCount++;
        }
        #endregion

        #region Test : Methods
        [TestCaseSource(nameof(Numbers))]
        public void TwoSumTest(int[] array, int target)
        {
            try
            {
                var actNumbers = DictionaryApproach.TwoSum(array, target);
                var expectedNumbers = new int[] { _expected[_expectedCount, 0], _expected[_expectedCount, 1] };
                Assert.That(actNumbers, Is.EqualTo(expectedNumbers));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region Test case sources
        private static IEnumerable<TestCaseData> Numbers
        {
            get
            {
                var rows = TwoSumNumbersArgument.GetLength(0);
                for (int i = 0; i < rows;)
                {
                    var list = new List<int>();
                    var target = TwoSumNumbersArgument[i, 0];
                    do
                    {
                        list.Add(TwoSumNumbersArgument[i, 1]);
                        i++;
                    } while (i < rows && TwoSumNumbersArgument[i, 0] == target);
                    var array = list.ToArray();
                    yield return new TestCaseData(array, target).SetName($"TwoSumNumbersArgument{target}");
                }
            }
        }
        #endregion
    }
    #endregion
}