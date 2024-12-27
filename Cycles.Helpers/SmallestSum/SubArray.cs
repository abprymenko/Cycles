namespace Cycles.LeetCodeTasks.SmallestSum;

#region SubArray
public class SubArray
{
    #region Public : Methods
    
    #region Task
    /*
     Given an array of integers, please write a function that returns length of the smallest sub array that
     sums to zero.
     Write a unit test to test the function
     Example:
     [4, 3, 2,-3,-2, 1,-1,-2] output is 2
    */
    #endregion

    /// <summary>
    /// Returns length of the smallest sub array that sums to zero.
    /// </summary>
    /// <param name="array">Given an array of integers.</param>
    /// <returns></returns>
    public static int MinLength(int[] array)
    {
        var minLength = int.MaxValue;
        for (var i = 0; i < array.Length; i++)//record
        {
            var sum = array[i];
            for (var j = i + 1; j < array.Length; j++)//cursor
            {
                sum += array[j];
                if (sum == 0 && array[j] != 0)
                {
                    var length = j - i + 1;
                    minLength = Math.Min(minLength, length);
                }
            }
        }
        return minLength == int.MaxValue ? 0 : minLength;
    }
    #endregion
}
#endregion