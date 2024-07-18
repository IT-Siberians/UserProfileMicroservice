using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

public class EmailValidator : IValidator<String>
{
    public const int MAXIMUM_EMAIL_LENGTH = 255;

    private String _exceptionMessage = String.Empty;

    public bool Validate(string value)
    {
        if (value == null)
        {
            _exceptionMessage = "Email cannot be null";
            return false;
        }
        if (value == String.Empty)
        {
            _exceptionMessage = "Email cannot be empty";
            return false;
        }
        if (value.Length > MAXIMUM_EMAIL_LENGTH)
        {
            _exceptionMessage = $"Invalid email address  length. Maximum length is {MAXIMUM_EMAIL_LENGTH}. Email value: {value}";
            return false;
        }
        if (!IsValidEmailAddressFormat(value))
        {
            _exceptionMessage = "Invalid email address format. Email value: " + value;
            return false;
        }
        return true;
    }

    public Exception GetValidationException()
    {
        return new EmailValidationException(_exceptionMessage);
    }

    private bool IsValidEmailAddressFormat(string email)
    {
        string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
        Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
        return isMatch.Success;
    }
}