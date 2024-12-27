namespace Cycles.Patterns.BusinessObjects.Sides;

#region SideB
public class SideB : BaseSide
{
    #region Public : Methods
    public override void FillOutObjects(int count, int length, int delay)
    {
        var array = new object[length];
        int i = 0, j = 0;
        while (i < count)
        {
            while (j < length)
            {
                array[j] = j;
                j++;
            }
            lock (Objects)
            {
                Objects.Add(array);
            }
            Task.Delay(delay).Wait();
            i++;
        }
    }
    #endregion
}
#endregion