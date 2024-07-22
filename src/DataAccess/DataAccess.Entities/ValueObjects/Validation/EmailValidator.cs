using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class EmailValidator : IValidator<String>
{
    const int MAXIMUM_EMAIL_LENGTH = 255;

    public void Validate(string value)
    {
        if (value == null)
            ThrowValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            ThrowValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (value.Length > MAXIMUM_EMAIL_LENGTH)
            throw new EmailValidationException(ExceptionMessages.MAXIMUM_STRING_LENGTH_EXCEEDED);
        if (!IsValidEmailAddressFormat(value))
            ThrowValidationException(ExceptionMessages.INVALID_EMAIL_FORMAT);
    }

    private bool IsValidEmailAddressFormat(string email)
    {
        string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
        Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
        return isMatch.Success;
    }

    private void ThrowValidationException(string message)
        => throw new EmailValidationException(message);
}