using UserProfileMicroservice.DataAccess.ValueObjects.Base;
using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.EmailValidationExceptions;
using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.PhoneNumberValidationExceptions;
using static UserProfileMicroservice.Common.Validation.PhoneNumberValidationHelper;

namespace UserProfileMicroservice.DataAccess.ValueObjects;

public class PhoneNumber(string phoneNumber) : ValueObject<string>(phoneNumber)
{
    protected override void Validate(string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new PhoneNumberIsEmptyException();
        if (value.Length > PhoneNumberMaximumLength)
            throw new PhoneNumberMaximumLengthException(value, PhoneNumberMaximumLength);
        if (!PhoneNumberFormatRegex.IsMatch(value))
            throw new PhoneNumberFormatException(value, PhoneNumberFormatPattern);
    }
}
