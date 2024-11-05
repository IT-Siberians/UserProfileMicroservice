using System.Text.RegularExpressions;

namespace UserProfileMicroservice.Common.Validation;

public static class LastNameValidationHelper
{
    public const int LastNameMaximumLength = 30;
    public const string LastNameCharacterSetPattern = "(^[a-zA-Z]+$)|(^[а-яА-Я]+$)";
    public const string LastNameCapitalizationPattern = "(^[A-Z].[a-z]*$)|(^[А-Я].[а-я]*$)";
    public static readonly Regex LastNameCharacterSetRegex = new(LastNameCharacterSetPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
    public static readonly Regex LastNameCapitalizationRegex = new(LastNameCapitalizationPattern, RegexOptions.Compiled);
}
