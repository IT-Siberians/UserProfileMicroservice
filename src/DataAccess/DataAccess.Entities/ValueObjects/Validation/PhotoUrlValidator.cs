using DataAccess.Entities.ValueObjects.Exceptions;

namespace DataAccess.Entities.ValueObjects.Validation;

public class PhotoUrlValidator : IValidator<String>
{
    private String _exceptionMessage = String.Empty;

    public bool Validate(string value)
    {
        if (value == null)
        {
            _exceptionMessage = "Photo url cannot be null";
            return false;
        }
        if (value == String.Empty)
        {
            _exceptionMessage = "Photo url cannot be empty";
            return false;
        }
        if (!IsValidPhotoUrlFormat(value))
        {
            _exceptionMessage = "Invalid url format. Photo url value: " + value;
            return false;
        }
        return true;
    }

    public Exception GetValidationException()
    {
        return new PhotoUrlValidationException(_exceptionMessage);
    }

    private bool IsValidPhotoUrlFormat(string urlName)
    {
        return Uri.TryCreate(urlName, UriKind.Absolute, out Uri? uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}