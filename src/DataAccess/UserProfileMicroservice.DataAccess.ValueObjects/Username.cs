using UserProfileMicroservice.Common.Extensions;
using UserProfileMicroservice.DataAccess.ValueObjects.Base;
using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.UsernameValidationExceptions;
using static UserProfileMicroservice.Common.Validation.UsernameValidationHelper;

namespace UserProfileMicroservice.DataAccess.ValueObjects;

public class Username(string username) : ValueObject<string>(username)
{
    protected override void Validate(string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new UsernameIsEmptyException();
        if (value.Length > UsernameMaximumLength)
            throw new UsernameMaximumLengthException(value, UsernameMaximumLength);
        if (value.CountAlphanumericCharacters() < UsernameMinimumLength)
            throw new UsernameMinimumLengthException(value, UsernameMinimumLength);
        if (!UsernameCharacterSetRegex.IsMatch(value))
            throw new UsernameFormatException(value, UsernameCharacterSetPattern);
    }
}

