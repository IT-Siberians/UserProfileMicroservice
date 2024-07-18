using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

public class UsernameValidator : IValidator<String>
{
    public const int MAXIMUM_NAME_LENGTH = 30;
    public const int MINIMUM_NAME_LENGTH = 3;

    private String _exceptionMessage = String.Empty;

    public bool Validate(string value)
    {
        if (value == null)
        {
            _exceptionMessage = "Username cannot be null";
            return false;
        }
        if (value == String.Empty)
        {
            _exceptionMessage = "Username cannot be empty";
            return false;
        }
        if (value.Length > MAXIMUM_NAME_LENGTH)
        {
            _exceptionMessage = $"Invalid username  length. Maximum length is {MAXIMUM_NAME_LENGTH}. Username value: {value}";
            return false;
        }
        if (CountAlphanumericCharacters(value) < MINIMUM_NAME_LENGTH)
        {
            _exceptionMessage = $"Invalid username  length. the minimum number of alphanumeric characters is equal to {MINIMUM_NAME_LENGTH}. Username value: {value}";
            return false;
        }
        if (!IsValidCharacterSet(value))
        {
            _exceptionMessage = "The username contains invalid characters. Username value: " + value;
            return false;
        }
        return true;
    }

    public Exception GetValidationException()
    {
        return new UsernameValidationException(_exceptionMessage);
    }

    private bool IsValidCharacterSet(string name)
    {
        string pattern = "(^[a-zA-Z_-]+$)";
        Match isMatch = Regex.Match(name, pattern, RegexOptions.IgnoreCase);
        return isMatch.Success;
    }

    private int CountAlphanumericCharacters(string name)
        => name.Where(ch => Char.IsLetterOrDigit(ch)).Count();

}