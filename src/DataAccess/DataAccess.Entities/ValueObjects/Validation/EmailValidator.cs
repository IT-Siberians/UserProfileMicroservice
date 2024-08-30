using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class EmailValidator : IValidator<String>
{
    private const string EmailRegexPattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";

    public void Validate(string value)
    {
        if (value == null)
            throw new EmailValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            throw new EmailValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (value.Length > Email.MaximumValueLength)
            throw new EmailValidationException(ExceptionMessages.MAXIMUM_STRING_LENGTH_EXCEEDED);
        if (!IsValidEmailAddressFormat(value))
            throw new EmailValidationException(ExceptionMessages.INVALID_EMAIL_FORMAT);
    }

    private bool IsValidEmailAddressFormat(string email)
        => Regex.Match(email, EmailRegexPattern, RegexOptions.IgnoreCase).Success;
}