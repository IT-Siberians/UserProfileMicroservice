using DataAccess.Entities.ValueObjects.Enumerations;
using DataAccess.Entities.ValueObjects.Exceptions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class DataPublicityValidator : IValidator<int>
{
    private static readonly int PublicDataFlagsValuesSum = Enum.GetValues(typeof(PublicDataFlags)).Cast<int>().Sum(x => x);

    public void Validate(int value)
    {
        if (value < 0)
            throw new DataPublicityStateValidationException(ExceptionMessages.NEGATIVE_VALUE);
        if (value > PublicDataFlagsValuesSum)
            throw new DataPublicityStateValidationException(ExceptionMessages.MAXIMUM_VALUE_EXCEEDED);
    }
}