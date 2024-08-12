using DataAccess.Entities.ValueObjects.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class FirstNameValidator : IValidator<String>
{
    public void Validate(string value)
    {
        if (value == null)
            ThrowValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            ThrowValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (value.Length > FirstName.MaximumValueLength)
            ThrowValidationException(ExceptionMessages.MAXIMUM_VALUE_EXCEEDED);
        if (!IsValidCharacterSet(value))
            ThrowValidationException(ExceptionMessages.INVALID_NAME_CHARACTER_SET);
        if (!IsValidNameCapitalization(value))
            ThrowValidationException(ExceptionMessages.INVALID_NAME_CAPITALIZATION);
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

    [DoesNotReturn]
    private void ThrowValidationException(string message)
        => throw new FirstNameValidationException(message);
}