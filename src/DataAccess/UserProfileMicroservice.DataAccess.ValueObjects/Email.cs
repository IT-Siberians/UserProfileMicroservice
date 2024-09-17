using UserProfileMicroservice.DataAccess.ValueObjects.Base;
using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.EmailValidationExceptions;
using static UserProfileMicroservice.Common.Validation.EmailValidationHelper;

namespace UserProfileMicroservice.DataAccess.ValueObjects;

public class Email(string email) : ValueObject<string>(email)
{
    protected override void Validate(string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new EmailIsEmptyException();
        if (value.Length > EmailMaximumLength)
            throw new EmailMaximumLengthException(value, EmailMaximumLength);
        if (!EmailFormatRegex.IsMatch(value))
            throw new EmailFormatException(value, EmailRegexPattern);
    }
}
