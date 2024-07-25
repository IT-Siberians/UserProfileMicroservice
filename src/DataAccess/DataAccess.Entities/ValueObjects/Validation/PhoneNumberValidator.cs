using DataAccess.Entities.ValueObjects.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class PhoneNumberValidator : IValidator<String>
{
    const int MAXIMUM_PHONE_NUMBER_LENGTH = 14;

    public void Validate(string value)
    {
        if (value == null)
            ThrowValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            ThrowValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (value.Length > MAXIMUM_PHONE_NUMBER_LENGTH)
            ThrowValidationException(ExceptionMessages.MAXIMUM_STRING_LENGTH_EXCEEDED);
        if (!IsValidPhoneNumberFormat(value))
            ThrowValidationException(ExceptionMessages.INVALID_PHONE_NUMBER_FORMAT);
    }

    private bool IsValidPhoneNumberFormat(string name)
    {
        string pattern = @"^\+[0-9]+$";
        Match isMatch = Regex.Match(name, pattern, RegexOptions.None);
        return isMatch.Success;
    }

    [DoesNotReturn]
    private void ThrowValidationException(string message)
        => throw new PhoneNumberValidationException(message);
}