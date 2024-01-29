namespace Cycles.Helpers.AsynchronousFibonacci;

#region Recursion
public class Recursion
{
    #region Public : Methods
    public static async Task<int> FibonacciAsync(int number)
    {
        if (number <= 1)
            return number;
        return await FibonacciAsync(number - 1) + await FibonacciAsync(number - 2);
    }
    #endregion
}
#endregion