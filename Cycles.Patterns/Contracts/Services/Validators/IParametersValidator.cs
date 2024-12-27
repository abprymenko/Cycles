namespace Cycles.Patterns.Contracts.Services.Validators;

#region IParametersValidator
internal interface IParametersValidator
{
    int[] ValidateAndExtractIntegers(params int?[] parameters);
}
#endregion