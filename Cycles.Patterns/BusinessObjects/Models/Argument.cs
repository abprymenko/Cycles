namespace Cycles.Patterns.BusinessObjects.Models;

#region Usings
using Cycles.Patterns.Contracts.BusinessObjects.Models;
#endregion

#region Arguments
public class Argument : IArgument
{
    #region Public : Properties
    public virtual List<int[]> Lengths { get; set; } = [];
    public virtual int[]? Counts { get; set; }
    public virtual int[]? Delays { get; set; }
    #endregion
}
#endregion