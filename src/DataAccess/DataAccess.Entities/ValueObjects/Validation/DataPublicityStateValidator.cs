using DataAccess.Entities.ValueObjects.Exceptions;

namespace DataAccess.Entities.ValueObjects.Validation;

public class DataPublicityValidator : IValidator<Int32>
{
    public static readonly int MAXIMUM_VALUE = (int)PublicDataFlags.MaximumValue - 1;

    private String _exceptionMessage = String.Empty;

    public bool Validate(int value)
    {
        if (value < 0)
        {
            _exceptionMessage = "The value cannot be less than zero";
            return false;
        }
        if (value > MAXIMUM_VALUE)
        {
            _exceptionMessage = $"Value greater than maximum allowed value. Maximum value is {MAXIMUM_VALUE}. Validated value: {value}";
            return false;
        }
        return true;
    }

    public Exception GetValidationException()
    {
        return new DataPublicityStateValidationException(_exceptionMessage);
    }
}