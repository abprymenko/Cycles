namespace Cycles.Tests.HelpersTest.AsynchronousRecursion;

#region RecursionTest
internal class RecursionTest
{
    #region Private : Fields
    private static readonly int[] Arguments = [5, 10, 15, 20, 25, 30, 35, 40, 45];
    private readonly IEnumerable<int> _45Expected = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733];
    private readonly IEnumerable<ulong> _20Expected = [1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600, 6227020800, 87178291200, 1307674368000, 20922789888000, 35568742809600, 6402373705728000, 121645100408832000, 2432902008176640000];
    private const string TestOk = "Test Ok!";
    private const string TestNotOk = "Test not Ok!";
    #endregion

    #region Setup
    [SetUp]
    public void Setup()
    {
    }
    #endregion

    #region Test : Methods
    [TestCaseSource(nameof(FibonacciAsyncExceptionSources))]
    public void FibonacciAsyncExceptionTest(int number)
    {
        var ex = Assert.ThrowsAsync<Exception>(async () => await TaskThrowException<int, int>(number, _45Expected, Fibonacci.FibonacciAsync));
        Assert.That(ex.Message, Is.EqualTo(TestOk));
    }
    [TestCaseSource(nameof(FactorialAsyncExceptionSources))]
    public void FactorialAsyncExceptionTest(int number)
    {
        var ex = Assert.ThrowsAsync<Exception>(async () => await TaskThrowException<ulong, ulong>(number, _20Expected, Factorial.FactorialAsync));
        Assert.That(ex.Message, Is.EqualTo(TestOk));
    }
    #endregion

    #region Private : Methods
    private static async Task TaskThrowException<TIn, TOut>(int number, IEnumerable<TOut> expected, Func<TIn, Task<TOut>> func)
        where TIn : struct
        where TOut : struct
    {
        try
        {
            await foreach (var actDigit in GetSequenceAsync(number, func))
            {
                var isContained = expected?.Contains(actDigit);
                if (isContained.HasValue && !isContained.Value)
                    throw new Exception(TestNotOk);
            }
            throw new Exception(TestOk);
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
        for (var i = 0; i < count; ++i)
        {
            if (i is TIn tin)
            {
                yield return await func.Invoke(tin);
            }
        }
    }
    private static IEnumerable<TestCaseData> FibonacciAsyncExceptionSources
    {
        get
        {
            foreach (var argument in Arguments)
            {
                yield return new TestCaseData(argument).SetName($"Argument-{argument}");
            }
        }
    }
    private static IEnumerable<TestCaseData> FactorialAsyncExceptionSources
    {
        get
        {
            for (var i = 0; i < Arguments.Length - 5; i++)
            {
                yield return new TestCaseData(Arguments[i]).SetName($"Argument-{Arguments[i]}");
            }
        }
    }
    #endregion
}
#endregion