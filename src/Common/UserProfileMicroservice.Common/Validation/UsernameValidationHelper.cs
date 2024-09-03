using System.Text.RegularExpressions;

namespace UserProfileMicroservice.Common.Validation;

public static class UsernameValidationHelper
{
    public const int UsernameMinimumLength = 3;
    public const int UsernameMaximumLength = 30;
    public const string UsernameCharacterSetPattern = "(^[a-zA-Z_-]+$)";
    public static readonly Regex UsernameCharacterSetRegex = new(UsernameCharacterSetPattern, RegexOptions.Compiled);
}
