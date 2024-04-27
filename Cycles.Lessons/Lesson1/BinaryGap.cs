namespace Cycles.Lessons.Lesson1;

#region Usings
using Cycles.Extensions;
#endregion

#region BinaryGap
public class BinaryGap
{
    #region Public : Methods
    /// <summary>
    /// Obtaining the longest binary gap by using <seealso cref="Queue{T}"/>.
    /// </summary>
    /// <param name="n">Input parameter to convert to binary number system.</param>
    /// <returns><see cref="int"/></returns>
    public static int LongestBinaryGap(int n)
    {
        int i = 0, longestBinaryGap = 0;
        var bytes = n.ToQueueByte();
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