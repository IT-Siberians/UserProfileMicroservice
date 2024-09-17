using System.Text.RegularExpressions;

namespace UserProfileMicroservice.Common.Validation;

public static class PhotoUrlValidationHelper
{
    public static bool IsValidUrlFormat(string urlName)
        => Uri.TryCreate(urlName, UriKind.Absolute, out Uri? uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
}
