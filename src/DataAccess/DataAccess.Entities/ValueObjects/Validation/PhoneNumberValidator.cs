using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

public class PhoneNumberValidator : IValidator<String>
{
    public const int MAXIMUM_NAME_LENGTH = 30;

    private String _exceptionMessage = String.Empty;

    public bool Validate(string value)
    {
        if (value == null)
        {
            _exceptionMessage = "Phone number cannot be null";
            return false;
        }
        if (value == String.Empty)
        {
            _exceptionMessage = "Phone number cannot be empty";
            return false;
        }
        if (value.Length > MAXIMUM_NAME_LENGTH)
        {
            _exceptionMessage = $"Invalid phone number length. Maximum length is {MAXIMUM_NAME_LENGTH}. Phone number value: {value}";
            return false;
        }
        if (!IsValidPhoneNumberFormat(value))
        {
            _exceptionMessage = "The phone number must begin with a plus sign and all others characters must be digits. Phone number value: " + value;
            return false;
        }
        return true;
    }

    public Exception GetValidationException()
    {
        return new PhoneNumberValidationException(_exceptionMessage);
    }

    private bool IsValidPhoneNumberFormat(string name)
    {
        string pattern = @"^\+[0-9]+$";
        Match isMatch = Regex.Match(name, pattern, RegexOptions.None);
        return isMatch.Success;
    }
}