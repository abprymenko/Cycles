namespace Cycles.Library.LeetCodeTasks;

#region StringSwap
public static partial class Tasks
{
    #region Public : Methods
    /// <summary>
    ///     Checks if one string swap can make strings equal.
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns>True if it is possible to make both strings equal by performing <br/>
    /// at most one string swap on exactly one of the strings. Otherwise,false.</returns>
    public static bool CheckSwap(string str1, string str2)
    {
        var count = 0;
        var setA = new HashSet<char>();
        var setB = new HashSet<char>();
        for (var i = 0; i < str1.Length; i++)
        {
            setA.Add(str1[i]);
            setB.Add(str2[i]);
            if (str1[i] != str2[i])
                count++;
        }
        if (!setA.SetEquals(setB))
            return false;
        return count is 0 or 2;
    }
    #endregion
}
#endregion