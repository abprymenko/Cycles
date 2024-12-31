namespace Cycles.Patterns.Contracts.Infrastructure.Visitors;

#region Usings
using Cycles.Patterns.Contracts.Services.Sides;
#endregion

#region ISideVisitor
public interface ISideVisitor<in T> where T : ISide
{
    Task VisitSide(T side, int? count, int? length, int? delay);
}
#endregion