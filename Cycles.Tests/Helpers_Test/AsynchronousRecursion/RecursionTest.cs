namespace Cycles.Tests.Helpers_Test.AsynchronousRecursion;

#region RecursionTest
internal class RecursionTest
{
    #region Private : Fields
    private readonly IEnumerable<int> _45Expected = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733 };
    private readonly IEnumerable<ulong> _20Expected = new List<ulong> { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600, 6227020800, 87178291200, 1307674368000, 20922789888000, 35568742809600, 6402373705728000, 121645100408832000, 2432902008176640000};
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
        var ex = Assert.ThrowsAsync<Exception>(async () => await TaskThrowException<int, int>(number, _45Expected, Fibonacci.FibonacciAsync));
        Assert.That(ex.Message, Is.EqualTo(_testOk));
    }

    [Test]
    [TestCase(5)]//14 ms
    [TestCase(10)]//< 1 ms
    [TestCase(15)]//< 1 ms
    [TestCase(20)]//< 1 ms
    public void FactorialAsync_Exception_Test(int number)
    {
        var ex = Assert.ThrowsAsync<Exception>(async () => await TaskThrowException<ulong, ulong>(number, _20Expected, Factorial.FactorialAsync));
        Assert.That(ex.Message, Is.EqualTo(_testOk));
    }
    #endregion

    #region Private : Methods
    private async Task TaskThrowException<TIn, TOut>(int number, IEnumerable<TOut> expected, Func<TIn, Task<TOut>> func)
        where TIn : struct
        where TOut : struct
    {
        try
        {
            await foreach (var actDigit in GetSequenceAsync(number, func))
            {
                if (!expected.Contains(actDigit))
                    throw new Exception(_testNotOk);
            }
            throw new Exception(_testOk);
        }
        catch (Exception)
        {
            throw;
        }
    }
    private static async IAsyncEnumerable<TOut> GetSequenceAsync<TIn, TOut>(int count, Func<TIn, Task<TOut>> func)
        where TIn : struct
        where TOut : struct
    {
        for (int i = 0; i < count; ++i)
        {
            if (i is TIn tin)
            {
                yield return await func.Invoke(tin);
            }
        }
    }
    #endregion
}
#endregion