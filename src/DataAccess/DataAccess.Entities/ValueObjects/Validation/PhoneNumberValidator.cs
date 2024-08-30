using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class PhoneNumberValidator : IValidator<String>
{
    private const string PhoneNumberFormatPattern = @"^\+[0-9]+$";

    public void Validate(string value)
    {
        if (value == null)
            throw new PhoneNumberValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            throw new LastNameValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (value.Length > PhoneNumber.MaximumValueLength)
            throw new PhoneNumberValidationException(ExceptionMessages.MAXIMUM_STRING_LENGTH_EXCEEDED);
        if (!IsValidPhoneNumberFormat(value))
            throw new PhoneNumberValidationException(ExceptionMessages.INVALID_PHONE_NUMBER_FORMAT);
    }

    private bool IsValidPhoneNumberFormat(string name)
        => Regex.Match(name, PhoneNumberFormatPattern, RegexOptions.None).Success;
}