using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

public class LastNameValidator : IValidator<String>
{
    public const int MAXIMUM_NAME_LENGTH = 30;

    private String _exceptionMessage = String.Empty;

    public bool Validate(string value)
    {
        if (value == null)
        {
            _exceptionMessage = "Last name cannot be null";
            return false;
        }
        if (value == String.Empty)
        {
            _exceptionMessage = "Last name cannot be empty";
            return false;
        }
        if (value.Length > MAXIMUM_NAME_LENGTH)
        {
            _exceptionMessage = $"Invalid last name length. Maximum length is {MAXIMUM_NAME_LENGTH}. Last name value: {value}";
            return false;
        }
        if (!IsValidCharacterSet(value))
        {
            _exceptionMessage = "The name must be Latin only or Cyrillic only. Last name value: " + value;
            return false;
        }
        if (!IsValidNameCapitalization(value))
        {
            _exceptionMessage = "The name must begin with an uppercase letter and all others must be lowercase. Last name value: " + value;
            return false;
        }
        return true;
    }

    public Exception GetValidationException()
    {
        return new LastNameValidationException(_exceptionMessage);
    }

    private bool IsValidCharacterSet(string name)
    {
        string pattern = "(^[a-z]+$)|(^[а-я]+$)";
        Match isMatch = Regex.Match(name, pattern, RegexOptions.IgnoreCase);
        return isMatch.Success;
    }

    private bool IsValidNameCapitalization(string name)
    {
        string pattern = "(^[A-Z].[a-z]*$)|(^[А-Я].[а-я]*$)";
        Match isMatch = Regex.Match(name, pattern, RegexOptions.None);
        return isMatch.Success;
    }
}