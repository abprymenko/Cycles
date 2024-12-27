namespace Cycles.LeetCodeTasks.AsynchronousRecursion;

#region Factorial
public class Factorial
{
    public static async Task<ulong> FactorialAsync(ulong number)
    {
        if (number == 0)
            return 1;
        return number * await FactorialAsync(number - 1);
    }
}
#endregion