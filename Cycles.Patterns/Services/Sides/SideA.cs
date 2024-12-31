namespace Cycles.Patterns.Services.Sides;

#region SideA
public class SideA : BaseSide
{
    #region Public : Methods
    public override async Task ProcessData(int count, int length, int delay)
    {
        var array = new object[length];
        for (var i = 0; i < count; i++)
        {
            for (var j = 0; j < length; j++)
            {
                array[j] = $"{j}/{length} - {count}.";
            }
            lock (Data)
            {
                Data.Add(array);
            }
            await Task.Delay(delay);
        }
    }
    #endregion
}
#endregion