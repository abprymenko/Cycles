namespace Cycles.Extensions;

#region Convert
public static class Convert
{
    #region Public : Methods
    /// <summary>
    /// <see cref="int"/> to <see cref="byte"/> conversion.
    /// </summary>
    /// <param name="N">Decimal number.</param>
    /// <returns></returns>
    public static Queue<byte> ToQueueByte(this int N)
    {
        Queue<byte> bytes = new();
        while (N > 0)
        {
            var item = (byte)(N & 1);
            bytes.Enqueue(item);
            N >>= 1;
        }
        return bytes;
    }
    #endregion
}
#endregion