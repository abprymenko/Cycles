namespace Cycles.Patterns.Contracts.BusinessObjects.Models;

#region IArguments
public interface IArgument
{
    List<int[]> Lengths { get; set; }
    int[]? Counts { get; set; }
    int[]? Delays { get; set; }
}
#endregion