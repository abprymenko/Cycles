namespace Cycles.Helpers.SubstringUniqueCharacters;

#region SlidingWindowApproach
public class SlidingWindowApproach
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
        var longestSubstring = string.Empty;
        var currentSubstring = string.Empty;
        var uniqueChars = new HashSet<char>();
        foreach (var c in input)
        {
            if (uniqueChars.Contains(c))
            {
                LongestSubstring(currentSubstring, ref longestSubstring);
                var index = currentSubstring.IndexOf(c);
                currentSubstring = CurrentSubstring(currentSubstring, index);
            }
            currentSubstring += c;
            uniqueChars.Add(c);
        }
        LongestSubstring(currentSubstring, ref longestSubstring);
        return longestSubstring;
    }
    #endregion

    #region Private : Methods
    private static void LongestSubstring(string currentSubstring, ref string longestSubstring)
    {
        if (currentSubstring.Length > longestSubstring.Length)
        {
            longestSubstring = currentSubstring;
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