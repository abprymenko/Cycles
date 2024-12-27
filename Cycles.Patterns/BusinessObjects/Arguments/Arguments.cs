namespace Cycles.Patterns.BusinessObjects.Arguments;

#region Usings
using Cycles.Patterns.Contracts.BusinessObjects.Arguments;
#endregion

#region Arguments
public class Arguments : IArguments
{
    #region Public : Properties
    public virtual List<int[]> Lengths { get; set; } = [];
    public virtual int[]? Counts { get; set; }
    public virtual int[]? Delays { get; set; }
    #endregion
}
#endregion