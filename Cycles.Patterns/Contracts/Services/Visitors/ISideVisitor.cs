namespace Cycles.Patterns.Contracts.Services.Visitors;

#region Usings
using BusinessObjects.Sides;
#endregion

#region ISideVisitor
public interface ISideVisitor<in T> where T : ISide
{
    Task VisitSide(T side, int? count, int? length, int? delay);
}
#endregion