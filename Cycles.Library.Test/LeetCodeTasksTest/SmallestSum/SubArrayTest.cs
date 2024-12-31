namespace Cycles.Library.Test.LeetCodeTasksTest.SmallestSum;

#region SubArrayTest
#region Task
/*
 Given an array of integers, please write a function that returns length of the smallest sub array that
 sums to zero.
 Write a unit test to test the function
 Example:
 [4, 3, 2,-3,-2, 1,-1,-2] output is 2
*/
#endregion
internal class SubArrayTest
{
    #region Private : Fields
    private static readonly int[] Arguments00 = [1, 2, 3, 4, 5];
    private static readonly int[] Arguments01 = [2, 4, -2, 6, -9, 7, -3];
    private static readonly int[] Arguments02 = [0, 0, 0, 0, 0];
    private static readonly int[] Arguments20 = [4, 3, 2, -3, 0, -2, 1, -1, -2];
    private static readonly int[] Arguments21 = [1, 2, -2, 4, -1, 0];
    private static readonly int[] Arguments30 = [4, 2, 2, -3, 1, 0, 4];
    private static readonly int[] Arguments50 = [2, 0, 0, 1, -3];
    private readonly int[] _expected = [0, 2, 3, 5];
    #endregion

    #region Setup
    [SetUp]
    public void Setup()
    {
    }
    #endregion

    #region Test : Methods
    [TestCaseSource(nameof(MinLengthTest0Sources))]
    public void MinLengthTest0(int[] array)
    {
        var act = Tasks.MinLength(array);
        Assert.That(act, Is.EqualTo(_expected[0]));
    }
    [TestCaseSource(nameof(MinLengthTest2Sources))]
    public void MinLengthTest2(int[] array)
    {
        var act = Tasks.MinLength(array);
        Assert.That(act, Is.EqualTo(_expected[1]));
    }
    [TestCaseSource(nameof(MinLengthTest3Sources))]
    public void MinLengthTest3(int[] array)
    {
        var act = Tasks.MinLength(array);
        Assert.That(act, Is.EqualTo(_expected[2]));
    }
    [TestCaseSource(nameof(MinLengthTest5Sources))]
    public void MinLengthTest5(int[] array)
    {
        var act = Tasks.MinLength(array);
        Assert.That(act, Is.EqualTo(_expected[3]));
    }
    #endregion

    #region Test case sources
    private static IEnumerable<TestCaseData> MinLengthTest0Sources
    {
        get
        {
            yield return new TestCaseData(Arguments00).SetName("Arguments00");
            yield return new TestCaseData(Arguments01).SetName("Arguments01");
            yield return new TestCaseData(Arguments02).SetName("Arguments02");
        }
    }
    private static IEnumerable<TestCaseData> MinLengthTest2Sources
    {
        get
        {
            yield return new TestCaseData(Arguments20).SetName("Arguments20");
            yield return new TestCaseData(Arguments21).SetName("Arguments21");
        }
    }
    private static IEnumerable<TestCaseData> MinLengthTest3Sources
    {
        get
        {
            yield return new TestCaseData(Arguments30).SetName("Arguments30");
        }
    }
    private static IEnumerable<TestCaseData> MinLengthTest5Sources
    {
        get
        {
            yield return new TestCaseData(Arguments50).SetName("Arguments50");
        }
    }
    #endregion
}
#endregion