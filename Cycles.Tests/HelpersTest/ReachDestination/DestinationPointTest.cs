namespace Cycles.Tests.HelpersTest.ReachDestination;

#region DestinationPointTest
/*TASK
 *You are given the array paths, where paths[i] = [pointAi, pointBi] means there exists a direct path going from A-i point to B-i point.
 *It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination point.
 *Example:
 *Input: paths = [["PointA","PointB"],["PointB","PointC"], ["PointC", "PointD"]]
 *Output: "PointD"
 *Explanation: Starting at "PointA" point you will reach "PointD" point which is the destination point. 
 *Your trip consist of: "PointA" -> "PointB" -> "PointC" -> "PointD"
 */
internal class DestinationPointTest
{
    #region Private : Fields
    private static readonly string[,] StringArgument = { { "PointA","PointB"}, {"PointB","PointC"}, {"PointC","PointD"} };
    private static readonly int[,] IntArgument = { { 1,2}, {2,3}, {3,4} };
    private readonly object[] _expected = ["PointD", 4];
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
    [TestCaseSource(nameof(Paths))]
    public void GetDestinationPointTest<T>(T[,] paths)
    {
        var actStringArray = DestinationPoint.GetDestinationPoint(paths);
        Assert.That(actStringArray, Is.EqualTo(_expected[_expectedCount]));
    }
    #endregion

    #region Test case sources
    private static IEnumerable<TestCaseData> Paths
    {
        get
        {
            yield return new TestCaseData(StringArgument).SetName("StringArgument");
            yield return new TestCaseData(IntArgument).SetName("IntArgument");
        }
    }
    #endregion
}
#endregion