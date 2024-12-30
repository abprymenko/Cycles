namespace Cycles.Patterns.BusinessObjects.Sides;

#region SideB
public class SideB : BaseSide
{
    #region Public : Methods
    public override async Task ProcessData(int count, int length, int delay)
    {
        var array = new object[length];
        int i = 0, j = 0;
        while (i < count)
        {
            while (j < length)
            {
                array[j] = $"{j}/{length} - {count}.";
                j++;
            }
            lock (Data)
            {
                Data.Add(array);
            }
            await Task.Delay(delay);
            i++;
        }
    }
    #endregion
}
#endregion