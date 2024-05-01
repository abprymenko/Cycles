namespace Cycles.Tests.LessonsTest.Lesson1;

#region BinaryGapTest
internal class BinaryGapTest
{
    #region Private : Fields
    private static readonly int[] Arguments = [15, 18, 32, 1041];//0 => 1111, 2 => 10010, 0 => 100000, 5 => 10000010001
    private readonly int[] _expected = [ 0, 2, 5];
    #endregion

    #region Setup
    [SetUp]
    public void Setup()
    {
    }
    #endregion

    #region Test : Methods
    [TestCaseSource(nameof(LongestBinaryGapTestSources))]
    public void LongestBinaryGapTest(int n)
    {
        var longestBinaryGap = BinaryGap.LongestBinaryGap(n);
        Assert.That(_expected, Does.Contain(longestBinaryGap));
    }
    #endregion

    #region Test case sources
    private static IEnumerable<TestCaseData> LongestBinaryGapTestSources =>
        Arguments.Select(argument => new TestCaseData(argument).SetName($"Argument-{argument}"));
    #endregion
}
#endregion