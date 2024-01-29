namespace Cycles.Extensions;

#region Convert
public static class Convert
{
    #region Public : Methods
    /// <summary>
    /// Decimal to Binary conversion.
    /// </summary>
    /// <param name="N"></param>
    /// <returns></returns>
    public static Queue<byte> ToBinary(this int N)
    {
        var bytes = new Queue<byte>();
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