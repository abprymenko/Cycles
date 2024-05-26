namespace Cycles.Tests.HelpersTest.ReachDestination;

#region DestinationPointTest
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