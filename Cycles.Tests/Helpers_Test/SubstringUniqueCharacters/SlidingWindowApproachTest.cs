namespace Cycles.Tests.Helpers_Test.SubstringUniqueCharacters;

#region SlidingWindowApproachTest
internal class SlidingWindowApproachTest
{
    #region Private : Fields
    private readonly string[] _expected = new[] { "a string" , "i Prymenko"};
    private int _expectedCount = -1;
    #endregion
    
    #region Setup
    [SetUp]
    public void Setup()
    {
        _expectedCount ++;
    }
    #endregion

    #region Test : Methods
    [Test]
    [TestCase("This is a string")]
    [TestCase("Ich bin Andrii Prymenko und programmiere gerne")]
    public void GetLongestUniqueSubstring0_Test(string input)
    {
        var act = SlidingWindowApproach.GetLongestUniqueSubstring(input);
        Assert.That(act, Is.EqualTo(_expected[_expectedCount]));
    }
    #endregion
}
#endregion