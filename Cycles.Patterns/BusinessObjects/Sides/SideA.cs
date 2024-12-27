namespace Cycles.Patterns.BusinessObjects.Sides;

#region SideA
public class SideA : BaseSide
{
    #region Public : Methods
    public override void FillOutObjects(int count, int length, int delay)
    {
        var array = new object[length];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < length; j++)
            {
                array[j] = j;
            }
            lock (Objects)
            {
                Objects.Add(array);
            }
            Task.Delay(delay).Wait();
        }
    }
    #endregion
}
#endregion