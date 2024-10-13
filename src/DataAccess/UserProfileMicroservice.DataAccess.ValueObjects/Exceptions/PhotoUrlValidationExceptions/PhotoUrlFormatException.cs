namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.PhotoUrlValidationExceptions;

public class PhotoUrlFormatException(string value) : FormatException
{
    public string Value => value;

    public override string Message
        => $"The {typeof(PhotoUrl)} value {Value} does not match the url format.";
}
