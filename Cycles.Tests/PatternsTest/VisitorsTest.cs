namespace Cycles.Tests.PatternsTest;

#region Usings
using Patterns.BusinessObjects.Sides;
using Patterns.BusinessObjects.Arguments;
using Patterns.Services.Visitors;
using Patterns.Shared.Constants;
using Patterns.Contracts.BusinessObjects.Sides;
using Patterns.Contracts.BusinessObjects.Arguments;
using Patterns.Contracts.Services.Visitors;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
#endregion

#region VisitorsTest
internal class VisitorsTest
{
    #region Private : Fields
    private readonly object _expected = 151;
    private Stopwatch _stopwatch;
    private ISideVisitor<ISide> _visitor;
    #endregion

    #region Setup
    [SetUp]
    public void Setup()
    {
        _stopwatch = new Stopwatch();
        _visitor = new SideVisitor();
    }
    #endregion

    #region Test : Methods
    /// <summary>
    ///     Runs the tasks concurrently but with using FIFO.
    /// </summary>
    /// <param name="sides"></param>
    /// <param name="args"></param>
    /// <remarks>
    ///     To improve the performance and ensure that multiple tasks run <b>concurrently</b>,
    ///     you should consider running the tasks in <b>parallel</b> instead of sequentially awaiting each task.
    /// </remarks>
    /// <exception cref="ArgumentException"></exception>
    /// <returns></returns>
    [TestCaseSource(nameof(GetArguments))]
    public async Task SetObjects_ShouldBeSameCount_Test(IEnumerable<ISide> sides, IArguments args)
    {
        // Act
        _stopwatch.Start();
        if (sides is not ISide[] enumerable || enumerable.Length != args.Lengths.Count)
            throw new ArgumentException("There was passed wrong parameter!", nameof(sides));
        try
        {
            var tasks = new ConcurrentQueue<Task>();
            //var tasks = new List<Task>();
            var firstStop = _stopwatch.ElapsedMilliseconds;
            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            //var i = 0;
            await foreach (var task in DownloadData(_visitor, enumerable, args, token))
            {
                //if (i == 0)
                //{
                //    await cancellationTokenSource.CancelAsync();
                //}
                Console.WriteLine(task.Id);
                tasks.Enqueue(task);
                //tasks.Add(task);
                //i++;
            }
            
            //1.
            //await Task.WhenAll(tasks);
            //1.

            //2.
            //i = 0;
            await foreach (var task in tasks.FirstInFirstOut(token))
            {
                //if (i == 1)
                //{
                //    await cancellationTokenSource.CancelAsync();
                //}
                Console.WriteLine(task.Id);
                await task;
                //i++;
            }
            //2.

            var secondStop = _stopwatch.ElapsedMilliseconds;
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(enumerable?[0].Objects, Has.Count.EqualTo(_expected),
                    string.Format(Formats.FailureMessage, "Objects", nameof(_expected), _expected,
                        enumerable?[0].Objects.Count, firstStop, secondStop, enumerable?[1].Objects.Count));
                Assert.That(enumerable?[1].Objects, Has.Count.EqualTo(_expected),
                    string.Format(Formats.FailureMessage, "Objects", nameof(_expected), _expected,
                        enumerable?[1].Objects.Count, firstStop, secondStop, enumerable?[0].Objects.Count));
            });
            var thirdStop = _stopwatch.ElapsedMilliseconds;
            _stopwatch.Stop();
            Console.WriteLine(Formats.HappyMessage, enumerable?[0].Objects.Count, enumerable?[1].Objects.Count,
                firstStop, secondStop, thirdStop);
        }
        catch (OperationCanceledException oce)
        {
            Assert.Pass(string.Format(Formats.PassMessage, oce.Message, _stopwatch.ElapsedMilliseconds,
                enumerable?[0].Objects.Count, enumerable?[1].Objects.Count));
            _stopwatch.Stop();
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }
    #endregion

    #region Private : Methods
    private static async IAsyncEnumerable<Task> DownloadData(ISideVisitor<ISide> visitor, ISide[] enumerable, IArguments args, [EnumeratorCancellation] CancellationToken token)
    {
        var tcs = new TaskCompletionSource<Task>();
        for (var i = 0; i < args?.Lengths?.Count; i++)
        {
            for (var j = 0; j < enumerable.Length; j++)
            {
                if (token.IsCancellationRequested)
                {
                    var addI = i % 2 == 0 ? 0 : 1;
                    tcs.SetException(new OperationCanceledException($"The DownloadData process has been interrupted on the current task with ID#{i+j+ addI+ 1} out of {args.Lengths?.Count + enumerable.Length} tasks."));
                    yield return await tcs.Task;
                }
                yield return enumerable[j].AcceptVisitor(visitor, args.Counts?[i], args.Lengths?[j][i], args.Delays?[j]);
            }
        }
    }
    #endregion

    #region Test case sources
    private static IEnumerable<TestCaseData> GetArguments
    {
        get
        {
            var arguments = new Arguments
            {
                Counts = [101, 50],
                Delays = [125, 25],
                Lengths = [[15, 14], [10, 11]]
            };
            var sideA = new SideA();
            var sideB = new SideB();
            ISide[] collections = [sideA, sideB];
            yield return new TestCaseData(collections, arguments).SetName(nameof(GetArguments));
        }
    }
    #endregion
}
#endregion