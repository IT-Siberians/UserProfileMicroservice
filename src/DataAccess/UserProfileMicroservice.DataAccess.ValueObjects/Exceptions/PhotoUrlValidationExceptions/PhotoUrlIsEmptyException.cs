namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.PhotoUrlValidationExceptions;



public class PhotoUrlIsEmptyException : ArgumentNullException
{
    public override string Message
        => $"Value of {typeof(PhotoUrl)} cannot be empty.";
}