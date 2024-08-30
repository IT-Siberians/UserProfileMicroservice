using DataAccess.Entities.ValueObjects.Exceptions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class PhotoUrlValidator : IValidator<String>
{
    public void Validate(string value)
    {
        if (value == null)
            throw new PhotoUrlValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            throw new PhotoUrlValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (!IsValidUrlFormat(value))
            throw new PhotoUrlValidationException(ExceptionMessages.INVALID_URL_FORMAT);
    }

    private bool IsValidUrlFormat(string urlName)
    {
        return Uri.TryCreate(urlName, UriKind.Absolute, out Uri? uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}