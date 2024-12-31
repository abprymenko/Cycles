namespace Cycles.Library.LeetCodeTasks;

#region SlidingWindowApproach
public static partial class Tasks
{
    #region Public : Methods
    /// <summary>
    /// A method that takes an input string and returns the longest substring with unique characters.<br/>
    /// It uses <c>a sliding window approach</c> to keep track of the current substring and a HashSet to check for uniqueness.<br/>
    /// The code then calls this method with the input string and prints the result.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string GetLongestUniqueSubstring(string input)
    {
        var longestUniqueSubstring = string.Empty;
        var currentSubstring = string.Empty;
        var uniqueCharacters = new HashSet<char>();
        foreach (var character in input)
        {
            if (uniqueCharacters.Contains(character))
            {
                LongestUniqueSubstring(currentSubstring, ref longestUniqueSubstring);
                var index = currentSubstring.IndexOf(character);
                currentSubstring = CurrentSubstring(currentSubstring, index);
            }
            currentSubstring += character;
            uniqueCharacters.Add(character);
        }
        LongestUniqueSubstring(currentSubstring, ref longestUniqueSubstring);
        return longestUniqueSubstring;
    }
    #endregion

    #region Private : Methods
    private static void LongestUniqueSubstring(string currentSubstring, ref string longestUniqueSubstring)
    {
        if (currentSubstring.Length > longestUniqueSubstring.Length)
        {
            longestUniqueSubstring = currentSubstring;
        }
    }
    /// <summary>
    /// In the code under, we have a string sentence and we use the range <c>0..^4</c> to get a substring excluding the last 4 characters: <br/>
    /// <code>
    /// //<b>csharp_style_prefer_range_operator = true</b> <br/>
    /// string sentence = "the quick brown fox"; <br/>
    /// var sub = sentence[0..^4]; <br/>
    /// </code>
    /// To add index + 1 to the substring, we can simply use [(index + 1)..] after the range to get the substring starting from the next character.
    /// </summary>
    /// <param name="currentSubstring"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    private static string CurrentSubstring(string currentSubstring, int index)
    {
        return currentSubstring[(index + 1)..]; //currentSubstring.Substring(index + 1);
    }
    #endregion
}
#endregion