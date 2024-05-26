namespace Cycles.Helpers.ReachDestination;

#region DestinationPoint
/*
 *You are given the array paths, where paths[i] = [pointAi, pointBi] means there exists a direct path going from pointAi to pointBi.
 *Return the destination point, that is, the point without any path outgoing to another point.
 *It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination point.
 *
 *Example 1:
 *Input: paths = [["PointA","PointB"],["PointB","PointC"], ["PointC", "PointD"]]
 *Output: "PointD"
 *
 *Explanation: Starting at "PointA" point you
 *will reach "PointD" point which is the destination point. Your trip consist of:
 *"PointA" -> "PointB" -> "PointC" -> "PointD"
 */
public static class DestinationPoint
{
    #region Public : Methods
    /// <summary>
    ///     Gets destination point.
    /// </summary>
    /// <param name="paths"></param>
    /// <returns></returns>
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