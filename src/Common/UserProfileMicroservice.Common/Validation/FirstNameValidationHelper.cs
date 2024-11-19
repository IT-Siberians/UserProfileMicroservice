using System.Text.RegularExpressions;

namespace UserProfileMicroservice.Common.Validation;

public static class FirstNameValidationHelper
{
    public const int FirstNameMaximumLength = 30;
    public const string FirstNameCharacterSetPattern = "(^[a-zA-Z]+$)|(^[а-яА-Я]+$)";
    public const string FirstNameCapitalizationPattern = "(^[A-Z].[a-z]*$)|(^[А-Я].[а-я]*$)";
    public static readonly Regex FirstNameCharacterSetRegex = new(FirstNameCharacterSetPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
    public static readonly Regex FirstNameCapitalizationRegex = new(FirstNameCapitalizationPattern, RegexOptions.Compiled);



}
