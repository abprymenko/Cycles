﻿namespace Cycles.Patterns.Services.Visitors;

#region Usings
using Validators;
using Cycles.Patterns.Contracts.Services.Validators;
using Cycles.Patterns.Contracts.BusinessObjects.Sides;
using Cycles.Patterns.Contracts.Services.Visitors;
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
    public Task VisitSide(ISide side, int? count, int? length, int? delay)
    {
        var result = _parametersValidator.ValidateAndExtractIntegers(count, length, delay);
        return Task.Run(() => FillOutObjects(side, result[0], result[1], result[2]));
    }
    #endregion

    #region Private : Methods
    public virtual void FillOutObjects(ISide side, int count, int length, int delay)
    {
        side.FillOutObjects(count, length, delay);
    }
    #endregion
}
#endregion