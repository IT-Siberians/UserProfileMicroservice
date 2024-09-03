using UserProfileMicroservice.DataAccess.ValueObjects.Base;
using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.FirstNameValidationExceptions;
using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.LastNameValidationExceptions;
using static UserProfileMicroservice.Common.Validation.LastNameValidationHelper;

namespace UserProfileMicroservice.DataAccess.ValueObjects;

public class LastName(string lastName) : ValueObject<string>(lastName)
{
    protected override void Validate(string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new LastNameIsEmptyException();
        if (value.Length > LastNameMaximumLength)
            throw new LastNameMaximumLengthException(value, LastNameMaximumLength);
        if (!LastNameCharacterSetRegex.IsMatch(value))
            throw new LastNameFormatException(value, LastNameCharacterSetPattern);
        if (!LastNameCapitalizationRegex.IsMatch(value))
            throw new LastNameFormatException(value, LastNameCapitalizationPattern);
    }
}

