using DataAccess.Entities.ValueObjects.Exceptions;

namespace DataAccess.Entities.ValueObjects.Validation;

internal class PhotoUrlValidator : IValidator<String>
{
    public void Validate(string value)
    {
        if (value == null)
            ThrowValidationException(ExceptionMessages.VALUE_IS_NULL);
        if (value == String.Empty)
            ThrowValidationException(ExceptionMessages.STRING_IS_EMPTY);
        if (!IsValidPhotoUrlFormat(value))
            ThrowValidationException(ExceptionMessages.INVALID_URL_FORMAT);
    }

    private bool IsValidPhotoUrlFormat(string urlName)
    {
        return Uri.TryCreate(urlName, UriKind.Absolute, out Uri? uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }

    private void ThrowValidationException(string message)
        => throw new PhotoUrlValidationException(message);
}