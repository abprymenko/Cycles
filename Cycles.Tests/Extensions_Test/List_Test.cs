namespace Cycles.Tests.Extensions_Test;

#region List_Test
internal class List_Test
{
    #region Private : Fields
    private readonly int[] _expected = new[] { 2, 1, 0 };
    #endregion

    #region Setup
    [SetUp]
    public void Setup()
    {
    }
    #endregion

    #region Test : Methods
    [TestCase(0, 100, 1, 50, 2, 150)]
    public async Task FirstInFirstOut_ShouldCancelTasks(int result0, int millisecondsDelay0,
                                                        int result1, int millisecondsDelay1,
                                                        int result2, int millisecondsDelay2)
    {
        var cts = new CancellationTokenSource();
        List<Task<int>> tasks;
        List<int> results;
        CreateInstances(result0, result1, result2,
                        millisecondsDelay0, millisecondsDelay1, millisecondsDelay2,
                        out tasks, out results);
        try
        {
            // Act
            cts.Cancel();
            await foreach (var task in tasks.FirstInFirstOut(cts.Token))
            {
                results.Add(await task);
            }
        }
        catch (Exception)
        {
            // Assert
            Assert.That(results, Is.Empty);
        }
    }
    [TestCase(0, 150, 1, 99, 2, 50)]
    public async Task FirstInFirstOut_ShouldReturnTasksInOrderDesc(int result0, int millisecondsDelay0,
                                                                   int result1, int millisecondsDelay1,
                                                                   int result2, int millisecondsDelay2)
    {
        List<Task<int>> tasks;
        List<int> results;
        CreateInstances(result0, result1, result2,
                        millisecondsDelay0, millisecondsDelay1, millisecondsDelay2,
                        out tasks, out results);
        try
        {
            // Act
            await foreach (var task in tasks.FirstInFirstOut(CancellationToken.None))
            {
                results.Add(await task);
            }
            // Assert
            Assert.That(results, Is.EqualTo(_expected).AsCollection);
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
    [TestCase(0, 1, 2)]
    public async Task FirstInFirstOut_RandomDelay(int result0, int result1, int result2)
    {
        var i = 0;
        List<Task<int>> tasks;
        List<int> results;
        CreateInstances(result0, result1, result2, 
                        new Random().Next(10, 150), new Random().Next(10, 150), new Random().Next(10, 150),
                        out tasks, out results);
        try
        {
            // Act
            await foreach (var task in tasks.FirstInFirstOut(CancellationToken.None))
            {
                results.Add(await task);
                i++;
            }
            // Assert
            Assert.That(results.Distinct().Count(), Is.EqualTo(i));
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
    #endregion

    #region Private : Methods
    private static void CreateInstances(int result0, int result1, int result2,
                                        int millisecondsDelay0, int millisecondsDelay1, int millisecondsDelay2, 
                                        out List<Task<int>> tasks, out List<int> results)
    {
        tasks = new()
        {
            Task.Delay(millisecondsDelay0).ContinueWith(t0 => result0),
            Task.Delay(millisecondsDelay1).ContinueWith(t1 => result1),
            Task.Delay(millisecondsDelay2).ContinueWith(t2 => result2)
        };
        results = new();
    }
    #endregion
}
#endregion