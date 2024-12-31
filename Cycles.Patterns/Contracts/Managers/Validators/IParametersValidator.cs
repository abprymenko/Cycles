namespace Cycles.Patterns.Contracts.Managers.Validators;

#region IParametersValidator
public interface IParametersValidator
{
    int[] ValidateAndExtractIntegers(params int?[] parameters);
}
#endregion