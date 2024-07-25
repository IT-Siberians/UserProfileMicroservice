using DataAccess.Entities.ValueObjects.Enumerations;
using DataAccess.Entities.ValueObjects.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class DataPublicityValidator : IValidator<int>
{
    readonly static int PublicDataFlagsValuesSum = Enum.GetValues(typeof(PublicDataFlags)).Cast<int>().Sum(x => x);

    public void Validate(int value)
    {
        if (value < 0)
            ThrowValidationException(ExceptionMessages.NEGATIVE_VALUE);
        if (value > PublicDataFlagsValuesSum)
            ThrowValidationException(ExceptionMessages.MAXIMUM_VALUE_EXCEEDED);
    }

    [DoesNotReturn]
    private void ThrowValidationException(string message)
        => throw new DataPublicityStateValidationException(message);
}