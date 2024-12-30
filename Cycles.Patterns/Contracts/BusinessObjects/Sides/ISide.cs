namespace Cycles.Patterns.Contracts.BusinessObjects.Sides;

#region Usings
using Cycles.Patterns.Contracts.BusinessObjects.Items;
using Services.Visitors;
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