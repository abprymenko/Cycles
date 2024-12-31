namespace Cycles.Library.LeetCodeTasks;

#region Fibonacci
public static partial class Tasks
{
    #region Public : Methods
    public static async Task<int> FibonacciAsync(int number)
    {
        if (number < 2)
            return number;
        return await FibonacciAsync(number - 1) + await FibonacciAsync(number - 2);
    }
    #endregion
}
#endregion