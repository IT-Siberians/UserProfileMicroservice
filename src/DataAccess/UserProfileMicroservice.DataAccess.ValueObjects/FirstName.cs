using UserProfileMicroservice.DataAccess.ValueObjects.Base;
using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.FirstNameValidationExceptions;
using static UserProfileMicroservice.Common.Validation.FirstNameValidationHelper;

namespace UserProfileMicroservice.DataAccess.ValueObjects;

public class FirstName(string firstName) : ValueObject<String>(firstName)
{
    protected override void Validate(string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new FirstNameIsEmptyException();
        if (value.Length > FirstNameMaximumLength)
            throw new FirstNameMaximumLengthException(value, FirstNameMaximumLength);
        if (!FirstNameCharacterSetRegex.IsMatch(value))
            throw new FirstNameFormatException(value, FirstNameCharacterSetPattern);
        if (!FirstNameCapitalizationRegex.IsMatch(value))
            throw new FirstNameFormatException(value, FirstNameCapitalizationPattern);
    }
}
