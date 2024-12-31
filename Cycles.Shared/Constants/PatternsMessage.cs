namespace Cycles.Shared.Constants;

#region PatternsMessage
public class PatternsMessage
{
    public const string Failure = "\tAssert.That({0}, Has.Count.EqualTo({1}))\r\n" +
                                  "\tExpected: property Count equal to {2}\r\n" +
                                  "\tBut was:  {3}\r\n" +
                                  "\tFirst stop (Milliseconds): {4}\r\n" +
                                  "\tSecond stop (Milliseconds): {5}\r\n" +
                                  "\tParallel collection (Count): {6}\r\n";
    public const string Success = "\tCollection 1 (Count): {0}\r\n" +
                                  "\tCollection 2 (Count): {1}\r\n" +
                                  "\tFirst stop (Milliseconds): {2}\r\n" +
                                  "\tSecond stop (Milliseconds): {3}\r\n" +
                                  "\tThird stop (Milliseconds): {4}\r\n";
    public const string Pass = "\tToken cancellation message: {0}\r\n" +
                               "\tTime: {1}\r\n" +
                               "\tCollection 1 (Count): {2}\r\n" +
                               "\tCollection 2 (Count): {3}\r\n";
}
#endregion