namespace DataAccess.Entities.ValueObjects.Exceptions;

public class PhotoUrlValidationException : Exception
{
    public PhotoUrlValidationException(string message)
        : base(message)
    {
    }
}
