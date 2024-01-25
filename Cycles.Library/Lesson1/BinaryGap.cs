namespace Cycles.Library.Lesson1;

public class BinaryGap
{
    /// <summary>
    /// Obtaining the longest binary gap.
    /// </summary>
    /// <param name="N">Input parameter to convert to binary number system.</param>
    /// <returns><see cref="int"/></returns>
    public static int GetLongestBinaryGap(int N)
    {
        var longestBinaryGap = 0;
        var i = 0;
        var isFirstLsbZero = (N & 1) == 0;
        while (N > 0)
        {
            var leastSignificantByte = (N & 1) == 0;
            N >>= 1;
            if (isFirstLsbZero && leastSignificantByte)
                continue;
            else if (leastSignificantByte)
            {
                i++;
                longestBinaryGap = i > longestBinaryGap
                                    ? i
                                    : longestBinaryGap;
            }
            else
            {
                isFirstLsbZero = false;
                i = 0;
            }
        }
        return longestBinaryGap;
    }
}