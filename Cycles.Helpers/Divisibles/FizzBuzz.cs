namespace Cycles.Helpers.Divisibles;

#region FizzBuzz
public static class FizzBuzz
{
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
        var array = new string[max];
        var answer = string.Empty;
        var i = 1;
        while (i <= max)
        {
            answer = i.ToString();
            if (i % 3 == 0)
                answer = "Fizz";
            if (i % 5 == 0)
                answer = int.TryParse(answer, out int _) 
                            ? "Buzz" 
                            : string.Concat(answer, "Buzz");
            array[i - 1] = answer;
            i++;
        }
        return array;
    }
    /// <summary>
    /// Gets answers by usings for cycle.
    /// </summary>
    /// <param name="max">Max range.</param>
    /// <returns></returns>
    public static string[] AnswersFor(int max)
    {
        var answers = new string[max];
        var answer = string.Empty;
        for (int i = 1; i <= max; i++)
        {
            answer = i.ToString();
            if (i % 3 == 0)
                answer = "Fizz";
            if (i % 5 == 0)
                answer = int.TryParse(answer, out int _)
                            ? "Buzz"
                            : string.Concat(answer, "Buzz");
            answers[i - 1] = answer;
        }
        return answers;
    }
    /// <summary>
    /// Gets answers by usings for cycle and yield.
    /// </summary>
    /// <param name="max">Max range.</param>
    /// <returns></returns>
    public static IEnumerable<string> AnswersForYield(int max)
    {
        var answer = string.Empty;
        for (int i = 1; i <= max; i++)
        {
            answer = i.ToString();
            if (i % 3 == 0)
                answer = "Fizz";
            if (i % 5 == 0)
                answer = int.TryParse(answer, out int _)
                            ? "Buzz"
                            : string.Concat(answer, "Buzz");
            yield return answer;
        }
    }
}
#endregion