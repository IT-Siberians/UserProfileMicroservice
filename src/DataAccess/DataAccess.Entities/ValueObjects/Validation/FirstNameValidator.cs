using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class FirstNameValidator : IValidator<String>
{
    private const string NAMECharacterSetPattern = "(^[a-z]+$)|(^[а-я]+$)";
    private const string NameCapitalizationPattern = "(^[A-Z].[a-z]*$)|(^[А-Я].[а-я]*$)";

    public void Validate(string value)
    {
        if (value == null)
            throw new FirstNameValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            throw new FirstNameValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (value.Length > FirstName.MaximumValueLength)
            throw new FirstNameValidationException(ExceptionMessages.MAXIMUM_VALUE_EXCEEDED);
        if (!IsValidCharacterSet(value))
            throw new FirstNameValidationException(ExceptionMessages.INVALID_NAME_CHARACTER_SET);
        if (!IsValidNameCapitalization(value))
            throw new FirstNameValidationException(ExceptionMessages.INVALID_NAME_CAPITALIZATION);
    }

    private bool IsValidCharacterSet(string name)
        => Regex.Match(name, NAMECharacterSetPattern, RegexOptions.IgnoreCase).Success;

    private bool IsValidNameCapitalization(string name)
        => Regex.Match(name, NameCapitalizationPattern, RegexOptions.None).Success;
}