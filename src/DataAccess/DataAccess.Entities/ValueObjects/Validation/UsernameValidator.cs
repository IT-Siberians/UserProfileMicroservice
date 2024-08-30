using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class UsernameValidator : IValidator<String>
{
    private const string UsernameCharacterSetPattern = "(^[a-zA-Z_-]+$)";
    private const int MINIMUM_NAME_LENGTH = 3;

    public void Validate(string value)
    {
        if (value == null)
            throw new UsernameValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            throw new UsernameValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (value.Length > Username.MaximumValueLength)
            throw new UsernameValidationException(ExceptionMessages.MAXIMUM_STRING_LENGTH_EXCEEDED);
        if (CountAlphanumericCharacters(value) < MINIMUM_NAME_LENGTH)
            throw new UsernameValidationException(ExceptionMessages.USERNAME_LENGTH_LESS_THAN_MINIMUM_VALUE);
        if (!IsValidCharacterSet(value))
            throw new UsernameValidationException(ExceptionMessages.INVALID_USERNAME_CHARACTER_SET);
    }

    private bool IsValidCharacterSet(string name)
        => Regex.Match(name, UsernameCharacterSetPattern, RegexOptions.IgnoreCase).Success;

    private int CountAlphanumericCharacters(string name)
        => name.Where(ch => Char.IsLetterOrDigit(ch)).Count();
}
