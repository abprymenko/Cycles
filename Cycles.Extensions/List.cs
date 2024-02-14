namespace Cycles.Extensions;

#region Usings
using System.Runtime.CompilerServices;
#endregion

#region List
public static class List
{
    #region Public : Methods
    /// <summary>
    /// Clears the task list on a FIFO basis.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="tasks">The task list.</param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public static async IAsyncEnumerable<Task<T>> FirstDoneFirstOut<T>(this List<Task<T>> tasks,
        [EnumeratorCancellation] CancellationToken ct)
    {
        while (tasks.Count > 0)
        {
            ct.ThrowIfCancellationRequested();
            var task = await Task.WhenAny(tasks);
            yield return task;
            tasks.Remove(task);
        }
    }
    #endregion
}
#endregion