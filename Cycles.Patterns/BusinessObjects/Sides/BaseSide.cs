namespace Cycles.Patterns.BusinessObjects.Sides;

#region Usings
using Cycles.Patterns.Contracts.BusinessObjects.Sides;
using Cycles.Patterns.Contracts.Services.Visitors;
#endregion

#region BaseSide
public abstract class BaseSide : ISide
{
    #region Public : Properties
    public virtual List<object[]> Data { get; set; } = [];
    #endregion

    #region Public : Methods
    public abstract Task ProcessData(int count, int length, int delay);
    public virtual async Task AcceptVisitor(ISideVisitor<ISide> visitor, int? count, int? length, int? delay)
    {
        await visitor.VisitSide(this, count, length, delay);
    }
    #endregion
}
#endregion