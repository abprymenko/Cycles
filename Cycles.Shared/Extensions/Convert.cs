namespace Cycles.Shared.Extensions;

#region Convert
public static class Convert
{
    #region Public : Methods
    /// <summary>
    /// <see cref="int"/> to <see cref="byte"/> conversion.
    /// </summary>
    /// <param name="n">Decimal number.</param>
    /// <returns></returns>
    public static Queue<byte> ToQueueByte(this int n)
    {
        Queue<byte> bytes = new();
        while (n > 0)
        {
            var item = (byte)(n & 1);
            bytes.Enqueue(item);
            n >>= 1;
        }
        return bytes;
    }
    #endregion
}
#endregion