using System.Globalization;

namespace UserProfileMicroservice.Common.Extensions;

public static class StringExtension
{
    private static CultureInfo s_currentCulture = CultureInfo.CurrentCulture;

    public static int CountAlphanumericCharacters(this String input)
    => input.Where(ch => Char.IsLetterOrDigit(ch)).Count();

    public static string ToTitleCase(this string input)
        => s_currentCulture.TextInfo.ToTitleCase(input);
}
