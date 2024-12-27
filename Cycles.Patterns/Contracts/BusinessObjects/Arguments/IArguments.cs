namespace Cycles.Patterns.Contracts.BusinessObjects.Arguments;

#region IArguments
public interface IArguments
{
    List<int[]> Lengths { get; set; }
    int[]? Counts { get; set; }
    int[]? Delays { get; set; }
}
#endregion