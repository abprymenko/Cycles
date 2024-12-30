namespace Cycles.LeetCodeTasks.Divisibles;

#region FizzBuzz
public class FizzBuzz
{
    #region Public : Methods
    
    #region Task
    /*
    Given an integer n, return a string array answer(1-indexed) where:
                • answer[i] == "FizzBuzz" if i is divisible by 3 and 5.
                • answer[i] == "Fizz" if i is divisible by 3.
                • answer[i] == "Buzz" if i is divisible by 5.
                • answer[i] == i(as a string) if none of the above conditions are true.
    */
    #endregion

    /// <summary>
    /// Gets answers by usings while cycle.
    /// </summary>
    /// <param name="max">Max range.</param>
    /// <returns></returns>
    public static string[] AnswersWhile(int max)
    {
        var answers = new string[max];
        var i = 1;
        while (i <= max)
        {
            var answer = string.Empty;
            if (i % 3 == 0)
                answer = "Fizz";
            if (i % 5 == 0)
                answer += "Buzz";
            answers[i - 1] = string.IsNullOrEmpty(answer) ? i.ToString() : answer;
            i++;
        }
        return answers;
    }
    /// <summary>
    /// Gets answers by usings for cycle.
    /// </summary>
    /// <param name="max">Max range.</param>
    /// <returns></returns>
    public static string[] AnswersFor(int max)
    {
        var answers = new string[max];
        for (int i = 1; i <= max; i++)
        {
            var answer = string.Empty;
            if (i % 3 == 0)
                answer = "Fizz";
            if (i % 5 == 0)
                answer += "Buzz";
            answers[i - 1] = string.IsNullOrEmpty(answer) ? i.ToString() : answer;
        }
        return answers;
    }
    /// <summary>
    ///     Gets answers by usings the for loop and the yield operator.
    /// </summary>
    /// <param name="max">Max range.</param>
    /// <returns></returns>
    public static IEnumerable<string> AnswersForYield(int max)
    {
        for (int i = 1; i <= max; i++)
        {
            var answer = string.Empty;
            if (i % 3 == 0)
                answer = "Fizz";
            if (i % 5 == 0)
                answer = string.Concat(answer, "Buzz");
            yield return string.IsNullOrEmpty(answer) ? i.ToString() : answer;
        }
    }
    #endregion
}
#endregion