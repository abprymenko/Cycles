namespace Cycles.Tests.Lessons_Test.Lesson1;

#region BinaryGapTest
internal class BinaryGapTest
{
    #region Private : Fields
    private readonly int[] _expected = new[] { 0, 2, 5 };
    #endregion

    #region Setup
    [SetUp]
    public void Setup()
    {
    }
    #endregion

    #region Test : Methods
    [Test]
    [TestCase(15)]//0 => 1111
    [TestCase(18)]//2 => 10010
    [TestCase(32)]//0 => 100000
    [TestCase(1041)]//5 => 10000010001
    public void LongestBinaryGap_Test(int n)
    {
        var longestBinaryGap = BinaryGap.LongestBinaryGap(n);
        Assert.That(_expected, Does.Contain(longestBinaryGap));
    }
    #endregion
}
#endregion