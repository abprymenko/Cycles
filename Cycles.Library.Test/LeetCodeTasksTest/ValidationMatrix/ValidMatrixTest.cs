namespace Cycles.Library.Test.LeetCodeTasksTest.ValidationMatrix;

#region ValidMatrixTest
/* TASK
 * An n x n matrix is valid if every row and every column contains all the integers from 1 to n (inclusive).
 * Example 1:
 * Input: array = [[1,2,3],[3,1,2),[2,3,1]]
 * Output: true
 * Explanation: In this case, n = 3, and
 * every row and column contains the numbers 1, 2, and 3.
 * Hence, we return true.
 */
internal class ValidMatrixTest
{
    #region Private : Fields
    private static readonly int[,] TrueArgument = { {1,2,3}, 
                                                    {3,1,2}, 
                                                    {2,3,1} };
    private static readonly int[,] FalseArgument = { {1,2,3}, 
                                                     {3,1,2}, 
                                                     {2,1,3} };
    private readonly bool[] _expected = [true, false];
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
    public void CheckMatrixTest(int[,] array)
    {
        var actStringArray = Tasks.CheckMatrix(array);
        Assert.That(actStringArray, Is.EqualTo(_expected[_expectedCount]));
    }
    #endregion

    #region Test case sources
    private static IEnumerable<TestCaseData> Strings
    {
        get
        {
            yield return new TestCaseData(TrueArgument).SetName("TrueArgument");
            yield return new TestCaseData(FalseArgument).SetName("FalseArgument");
        }
    }
    #endregion
}
#endregion