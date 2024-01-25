namespace Cycles.Test.Lesson1_Test;

internal class BinaryGap_Test
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(15)]//0 => 1111
    [TestCase(18)]//2 => 10010
    [TestCase(32)]//0 => 100000
    [TestCase(1041)]//5 => 10000010001
    public void GetLongestBinaryGap_Test(int N)
    {
        var expected = new int[] { 0, 2, 5 };
        var longestBinaryGap = BinaryGap.GetLongestBinaryGap(N);
        Assert.IsTrue(expected.Contains(longestBinaryGap));
    }
}