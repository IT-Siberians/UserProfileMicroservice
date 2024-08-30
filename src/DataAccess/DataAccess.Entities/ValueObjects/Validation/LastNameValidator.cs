using DataAccess.Entities.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class LastNameValidator : IValidator<String>
{
    private const string NAMECharacterSetPattern = "(^[a-z]+$)|(^[а-я]+$)";
    private const string NameCapitalizationPattern = "(^[A-Z].[a-z]*$)|(^[А-Я].[а-я]*$)";

    public void Validate(string value)
    {
        if (value == null)
            throw new LastNameValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            throw new LastNameValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (value.Length > LastName.MaximumValueLength)
            throw new LastNameValidationException(ExceptionMessages.MAXIMUM_VALUE_EXCEEDED);
        if (!IsValidCharacterSet(value))
            throw new LastNameValidationException(ExceptionMessages.INVALID_NAME_CHARACTER_SET);
        if (!IsValidNameCapitalization(value))
            throw new LastNameValidationException(ExceptionMessages.INVALID_NAME_CAPITALIZATION);
    }

    private bool IsValidCharacterSet(string name)
        => Regex.Match(name, NAMECharacterSetPattern, RegexOptions.IgnoreCase).Success;

    private bool IsValidNameCapitalization(string name)
        => Regex.Match(name, NameCapitalizationPattern, RegexOptions.None).Success;
}