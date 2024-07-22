namespace DataAccess.Entities.ValueObjects.Exceptions;

public class PhotoUrlValidationException : DomainValidationException
{
    public PhotoUrlValidationException(string message)
        : base(message)
    {
    }
}
