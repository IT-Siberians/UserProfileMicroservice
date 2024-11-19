using System.Globalization;
using static UserProfileMicroservice.Common.Validation.EmailValidationHelper;

namespace UserProfileMicroservice.Common.Extensions;

public static class StringExtension
{
    private static CultureInfo s_currentCulture = CultureInfo.CurrentCulture;

    public static int CountAlphanumericCharacters(this String input)
    => input.Where(ch => Char.IsLetterOrDigit(ch)).Count();

    public static string ToTitleCase(this string input)
        => s_currentCulture.TextInfo.ToTitleCase(input);

    public static bool IsEmailAddress(this string input)
        => !String.IsNullOrWhiteSpace(input) && input.Length < EmailMaximumLength && EmailFormatRegex.IsMatch(input);
}
