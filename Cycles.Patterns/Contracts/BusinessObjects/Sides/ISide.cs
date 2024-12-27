namespace Cycles.Patterns.Contracts.BusinessObjects.Sides;

#region Usings
using Services.Visitors;
#endregion

#region ISide
public interface ISide
{
    Task AcceptVisitor(ISideVisitor<ISide> visitor, int? count, int? length, int? delay);
    void FillOutObjects(int count, int length, int delay);
    List<object[]> Objects { get; set; }
}
#endregion