namespace Cycles.Patterns.BusinessObjects.Sides;

#region Usings
using Cycles.Patterns.Contracts.BusinessObjects.Sides;
using Cycles.Patterns.Contracts.Services.Visitors;
#endregion

#region BaseSide
public abstract class BaseSide : ISide
{
    #region Public : Properties
    public virtual List<object[]> Objects { get; set; } = [];
    #endregion

    #region Public : Methods
    public abstract void FillOutObjects(int count, int length, int delay);
    public virtual Task AcceptVisitor(ISideVisitor<ISide> visitor, int? count, int? length, int? delay)
    {
        return visitor.VisitSide(this, count, length, delay);
    }
    #endregion
}
#endregion