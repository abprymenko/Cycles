namespace Cycles.LeetCodeTasks.ReachDestination;

#region DestinationPoint
public static class DestinationPoint
{
    #region Public : Methods
    /// <summary>
    ///     Gets destination point.
    /// </summary>
    /// <param name="paths"></param>
    /// <returns>The destination point, that is, the point without any path outgoing to another point.</returns>
    public static T GetDestinationPoint<T>(T[,] paths)
    {
        var outs = new HashSet<T>();
        var ins = new HashSet<T>();
        var rows = paths.GetUpperBound(0) + 1;
        for (var i = 0; i < rows; i++)
        {
            outs.Add(paths[i,0]);
            ins.Add(paths[i,1]);
        }
        return ins
                .First(item => !outs.Contains(item));
    }
    #endregion
}
#endregion