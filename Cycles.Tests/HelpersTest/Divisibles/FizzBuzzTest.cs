namespace Cycles.Tests.HelpersTest.Divisibles;

#region FizzBuzzTest
internal class FizzBuzzTest
{
	#region Private : Fields
	private const int Argument = 60;
	private readonly string[] _expectedStringArray =
    [
        "1"
		,"2"
		,"Fizz"
		,"4"
		,"Buzz"
		,"Fizz"
		,"7"
		,"8"
		,"Fizz"
		,"Buzz"
		,"11"
		,"Fizz"
		,"13"
		,"14"
		,"FizzBuzz"
        ,"16"
		,"17"
		,"Fizz"
		,"19"
		,"Buzz"
		,"Fizz"
		,"22"
		,"23"
		,"Fizz"
		,"Buzz"
		,"26"
		,"Fizz"
		,"28"
		,"29"
		,"FizzBuzz"
		,"31"
		,"32"
		,"Fizz"
		,"34"
		,"Buzz"
		,"Fizz"
		,"37"
		,"38"
		,"Fizz"
		,"Buzz"
		,"41"
		,"Fizz"
		,"43"
		,"44"
		,"FizzBuzz"
		,"46"
		,"47"
		,"Fizz"
		,"49"
		,"Buzz"
		,"Fizz"
		,"52"
		,"53"
		,"Fizz"
		,"Buzz"
		,"56"
		,"Fizz"
		,"58"
		,"59"
		,"FizzBuzz"
    ];
    #endregion

    #region Setup
    [SetUp]
    public void Setup()
    {
	}
    #endregion

    #region Test : Methods
    [TestCaseSource(nameof(Max))]
	public void AnswersWhileTest(int max)
	{
		var actStringArray = FizzBuzz.AnswersWhile(max);
		Assert.That(actStringArray, Is.EquivalentTo(_expectedStringArray));
	}
    [TestCaseSource(nameof(Max))]
    public void AnswersForTest(int max)
    {
        var actStringArray = FizzBuzz.AnswersFor(max);
        Assert.That(actStringArray, Is.EquivalentTo(_expectedStringArray));
    }
    [TestCaseSource(nameof(Max))]
    public void AnswersForYieldTest(int max)
    {
        var i = 0;
        foreach (var answer in FizzBuzz.AnswersForYield(max))
        {
            Assert.That(answer, Is.EquivalentTo(_expectedStringArray[i]));
            i++;
        }
    }
    #endregion

    #region Test case sources
    private static IEnumerable<TestCaseData> Max
    {
        get
        {
            yield return new TestCaseData(Argument).SetName("Argument");
        }
    }
    #endregion
}
#endregion