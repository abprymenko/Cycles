namespace Cycles.Patterns.Contracts.Services.Sides;

#region Usings
using Cycles.Patterns.Contracts.Infrastructure.Visitors;
using Cycles.Patterns.Contracts.Services.Items;
#endregion

#region ISide
public interface ISide : IItem
{
    #region Behavior
    Task AcceptVisitor(ISideVisitor<ISide> visitor, int? count, int? length, int? delay);
    Task ProcessData(int count, int length, int delay);
    #endregion
}
#endregion