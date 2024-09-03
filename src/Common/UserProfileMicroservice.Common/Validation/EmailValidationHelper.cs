using System.Text.RegularExpressions;

namespace UserProfileMicroservice.Common.Validation;

public static class EmailValidationHelper
{
    public const int EmailMaximumLength = 255;
    public const string EmailRegexPattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
    public static readonly Regex EmailFormatRegex = new(EmailRegexPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
}
