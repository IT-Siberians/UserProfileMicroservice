using UserProfileMicroservice.DataAccess.ValueObjects.Base;
using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.EmailValidationExceptions;
using UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.PhotoUrlValidationExceptions;
using static UserProfileMicroservice.Common.Validation.PhotoUrlValidationHelper;

namespace UserProfileMicroservice.DataAccess.ValueObjects;

public class PhotoUrl(string photoUrl) : ValueObject<string>(photoUrl)
{
    protected override void Validate(string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            throw new PhotoUrlIsEmptyException();
        if (!IsValidUrlFormat(value))
            throw new PhotoUrlFormatException(value);
    }
}
