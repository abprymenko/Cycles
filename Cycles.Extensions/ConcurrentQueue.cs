namespace Cycles.Extensions;

#region Usings
using System.Runtime.CompilerServices;
using System.Collections.Concurrent;
#endregion

#region ConcurrentQueue
public static class ConcurrentQueue
{
    #region Public : Methods
    /// <summary>
    ///     Clears the task list on a FIFO basis.
    /// </summary>
    /// <param name="tasks">The task list.</param>
    /// <param name="token"></param>
    /// <returns></returns>
    public static async IAsyncEnumerable<Task> FirstInFirstOut(this ConcurrentQueue<Task> tasks,
        [EnumeratorCancellation] CancellationToken token)
    {
        var count = tasks.Count;
        while (!tasks.IsEmpty)
        {
            var tcs = new TaskCompletionSource<Task>();
            tasks.TryDequeue(out var task);
            if (token.IsCancellationRequested)
            {
                tcs.SetException(new OperationCanceledException($"The process has been interrupted on the current task with ID#{task?.Id} out of {count} tasks."));
                yield return await tcs.Task;
            }
            if (task == null) continue;
            yield return task;
        }
    }
    #endregion
}
#endregion