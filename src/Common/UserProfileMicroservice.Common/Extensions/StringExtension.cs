namespace UserProfileMicroservice.Common.Extensions;

public static class StringExtension
{
    public static int CountAlphanumericCharacters(this String input)
    => input.Where(ch => Char.IsLetterOrDigit(ch)).Count();
}
