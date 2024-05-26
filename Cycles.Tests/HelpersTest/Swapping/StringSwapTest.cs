namespace Cycles.Tests.HelpersTest.Swapping;

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
        var actStringArray = StringSwap.CheckSwap(str1, str2);
        Assert.That(actStringArray, Is.EqualTo(_expected[_expectedCount]));
    }
    #endregion

    #region Test case sources
    private static IEnumerable<TestCaseData> Strings
    {
        get
        {
            yield return new TestCaseData(SwapStringArgument[0,0], SwapStringArgument[0, 1]).SetName("SwapStringArgument0");
            yield return new TestCaseData(SwapStringArgument[1,0], SwapStringArgument[1, 1]).SetName("SwapStringArgument1");
            yield return new TestCaseData(SwapStringArgument[2,0], SwapStringArgument[2, 1]).SetName("SwapStringArgument2");
            yield return new TestCaseData(SwapStringArgument[3,0], SwapStringArgument[3, 1]).SetName("SwapStringArgument3");
        }
    }
    #endregion
}
#endregion