namespace Cycles.Patterns.Infrastructure.Visitors;

#region Usings
using Cycles.Patterns.Managers.Validators;
using Cycles.Patterns.Contracts.Managers.Validators;
using Cycles.Patterns.Contracts.Infrastructure.Visitors;
using Cycles.Patterns.Contracts.Services.Sides;
#endregion

#region SideVisitor
public class SideVisitor : ISideVisitor<ISide>
{
    #region Private : Fields
    /// <summary>
    ///     Set this <see cref="_parametersValidator"/> field by using DI and then you can remove the pragma. 
    /// </summary>
#pragma warning disable CA1859
    private readonly IParametersValidator _parametersValidator = new ParametersValidator();
#pragma warning restore CA1859
    #endregion

    #region Public : Methods
    public async Task VisitSide(ISide side, int? count, int? length, int? delay)
    {
        var result = _parametersValidator.ValidateAndExtractIntegers(count, length, delay);
        await ProcessData(side, result[0], result[1], result[2]);
    }
    #endregion

    #region Private : Methods
    private static async Task ProcessData(ISide side, int count, int length, int delay)
    {
        await side.ProcessData(count, length, delay);
    }
    #endregion
}
#endregion