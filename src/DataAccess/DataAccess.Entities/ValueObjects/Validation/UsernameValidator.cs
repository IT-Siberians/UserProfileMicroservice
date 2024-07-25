using DataAccess.Entities.ValueObjects.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class UsernameValidator : IValidator<String>
{
    public const int MAXIMUM_NAME_LENGTH = 30;
    public const int MINIMUM_NAME_LENGTH = 3;

    public void Validate(string value)
    {
        if (value == null)
            ThrowValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            ThrowValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (value.Length > MAXIMUM_NAME_LENGTH)
            ThrowValidationException(ExceptionMessages.MAXIMUM_STRING_LENGTH_EXCEEDED);
        if (CountAlphanumericCharacters(value) < MINIMUM_NAME_LENGTH)
            ThrowValidationException(ExceptionMessages.USERNAME_LENGTH_LESS_THAN_MINIMUM_VALUE);
        if (!IsValidCharacterSet(value))
            ThrowValidationException(ExceptionMessages.INVALID_USERNAME_CHARACTER_SET);
    }

    private bool IsValidCharacterSet(string name)
    {
        string pattern = "(^[a-zA-Z_-]+$)";
        Match isMatch = Regex.Match(name, pattern, RegexOptions.IgnoreCase);
        return isMatch.Success;
    }

    private int CountAlphanumericCharacters(string name)
        => name.Where(ch => Char.IsLetterOrDigit(ch)).Count();

    [DoesNotReturn]    
        private void ThrowValidationException(string message)
        => throw new UsernameValidationException(message);
}
