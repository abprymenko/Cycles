namespace Cycles.Patterns.Managers.Validators;

#region Usings
using Cycles.Patterns.Contracts.Managers.Validators;
#endregion

#region ParametersValidator
public class ParametersValidator : IParametersValidator
{
    public int[] ValidateAndExtractIntegers(params int?[] parameters)
    {
        var result = new int[parameters.Length];

        for (var i = 0; i < parameters.Length; i++)
        {
            if (parameters[i] is not { } value)
                throw new ArgumentException($"Parameter at index {i} is invalid!");
            result[i] = value;
        }
        return result;
    }
}
#endregion