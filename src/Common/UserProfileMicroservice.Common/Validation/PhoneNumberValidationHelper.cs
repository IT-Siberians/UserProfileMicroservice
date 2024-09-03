using System.Text.RegularExpressions;

namespace UserProfileMicroservice.Common.Validation;

public static class PhoneNumberValidationHelper
{
    public const int PhoneNumberMaximumLength = 12;
    public const string PhoneNumberFormatPattern = @"^\+[0-9]+$";
    public static readonly Regex PhoneNumberFormatRegex = new(PhoneNumberFormatPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
}
