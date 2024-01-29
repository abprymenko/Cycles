namespace Cycles.Lessons.Lesson1;

#region Usings
using Cycles.Extensions;
#endregion

#region BinaryGap
public class BinaryGap
{
    #region Public : Methods
    /// <summary>
    /// Obtaining the longest binary gap.
    /// </summary>
    /// <param name="N">Input parameter to convert to binary number system.</param>
    /// <returns><see cref="int"/></returns>
    public static int GetLongestBinaryGap(int N)
    {
        var longestBinaryGap = 0;
        var isFirstLsbZero = (N & 1) == 0;
        for (var i = 0; N > 0; N >>= 1)
        {
            if (isFirstLsbZero && (N & 1) == 0)
                continue;
            else
            {
                if ((N & 1) == 0)
                {
                    i++;
                    longestBinaryGap = Math.Max(longestBinaryGap, i);
                    continue;
                }
                isFirstLsbZero = false;
                i = 0;
            }
        }
        return longestBinaryGap;
    }
    /// <summary>
    /// Obtaining the longest binary gap by using <seealso cref="Queue{T}"/>.
    /// </summary>
    /// <param name="N">Input parameter to convert to binary number system.</param>
    /// <returns><see cref="int"/></returns>
    public static int GetLongestBinaryGapQueue(int N)
    {
        int i = 0, longestBinaryGap = 0;
        var bytes = N.ToBinary();
        bytes.DequeueZeros();
        while (bytes.Count > 0)
        {
            if (bytes.Peek() == 1)
            {
                longestBinaryGap = Math.Max(longestBinaryGap, i);
                bytes.Dequeue();
                i = 0;
                continue;
            }
            i++;
            bytes.Dequeue();
        }
        return longestBinaryGap;
    }
    #endregion
}
#endregion