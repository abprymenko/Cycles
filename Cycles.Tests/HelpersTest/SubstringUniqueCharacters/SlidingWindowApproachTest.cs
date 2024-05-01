namespace Cycles.Tests.HelpersTest.SubstringUniqueCharacters;

#region SlidingWindowApproachTest
internal class SlidingWindowApproachTest
{
    #region Private : Fields
    private static readonly string[] Arguments = ["This is a string", "Ich bin Andrii Prymenko und programmiere gerne"];
    private readonly string[] _expected = [ "a string" , "i Prymenko"];
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
    [TestCaseSource(nameof(LongestUniqueSubstringTestSources))]
    public void GetLongestUniqueSubstringTest(string input)
    {
        var act = SlidingWindowApproach.GetLongestUniqueSubstring(input);
        Assert.That(act, Is.EqualTo(_expected[_expectedCount]));
    }
    #endregion

    #region Test case sources
    private static IEnumerable<TestCaseData> LongestUniqueSubstringTestSources => 
        Arguments.Select(argument => new TestCaseData(argument).SetName($"Argument-{argument}"));
    #endregion
}
#endregion