namespace Cycles.Library.Test.LeetCodeTasksTest.Swapping;

#region StringSwapTest
/* TASK
 * You are given two strings str1 and str2 of equal length.
 * A string swap is an operation where you choose two indices in a string (not necessarily different)
 * and swap the characters at these indices.
 * Input: str1 = ""string1"", str2 = ""1trings""
 * Output: true
 * Explanation: For example, swap the first character with the last character of str2 to make ""string1"".
 */
internal class StringSwapTest
{
    #region Private : Fields
    private static readonly string[,] SwapStringArgument = { { "string1", "1trings" }, 
                                                             { "test", "tset" },
                                                             { "static", "stitac"},
                                                             { "private", "eravitp"}
    };
    private readonly bool[] _expected = [true, true, true, false];
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
    [TestCaseSource(nameof(Strings))]
    public void CheckSwapTest(string str1, string str2)
    {
        var actStringArray = Tasks.CheckSwap(str1, str2);
        Assert.That(actStringArray, Is.EqualTo(_expected[_expectedCount]));
    }
    #endregion

    #region Test case sources
    private static IEnumerable<TestCaseData> Strings
    {
        get
        {
            for (int i = 0; i < SwapStringArgument.GetLength(0); i++)
            {
                yield return new TestCaseData(SwapStringArgument[i, 0], SwapStringArgument[i, 1])
                    .SetName($"SwapStringArgument{i}");
            }
        }
    }
    #endregion
}
#endregion