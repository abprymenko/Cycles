namespace Cycles.Tests.Helpers_Test.AsynchronousRecursion;

#region Recursion_Test
internal class Recursion_Test
{
    #region Private : Fields
    private readonly IEnumerable<int> _45expected = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733 };
    private readonly string _testOk = "Test Ok!";
    private readonly string _testNotOk = "Test not Ok!";
    #endregion

    #region Setup
    [SetUp]
    public void Setup()
    {
    }
    #endregion

    #region Test : Methods
    [Test]
    [TestCase(5)]//14 ms
    [TestCase(10)]//< 1 ms
    [TestCase(15)]//< 1 ms
    [TestCase(20)]//2 ms
    [TestCase(25)]//32 ms
    [TestCase(30)]//259 ms
    [TestCase(35)]//2.9 sec
    [TestCase(40)]//30.9 sec
    [TestCase(45)]//5.7 min
    public void FibonacciAsync_Exception_Test(int number)
    {
        Exception ex = Assert.ThrowsAsync<Exception>(async () => await TaskThrowException(number));
        Assert.That(ex.Message, Is.EqualTo(_testOk));
    }
    #endregion

    #region Private : Methods
    private async Task TaskThrowException(int number)
    {
        try
        {
            await foreach (var actDigit in GetSequenceAsync(number, Fibonacci.FibonacciAsync))
            {
                if (!_45expected.Contains(actDigit))
                    throw new Exception(_testNotOk);
            }
            throw new Exception(_testOk);
        }
        catch (Exception)
        {
            throw;
        }
    }
    private async static IAsyncEnumerable<int> GetSequenceAsync(int count, Func<int, Task<int>> func)
    {
        for (int i = 0; i < count; ++i)
        {
            yield return await func.Invoke(i);
        }
    }
    #endregion
}
#endregion