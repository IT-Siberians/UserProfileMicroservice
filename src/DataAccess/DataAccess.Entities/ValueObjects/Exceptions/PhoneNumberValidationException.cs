namespace DataAccess.Entities.ValueObjects.Exceptions;

public class PhoneNumberValidationException : DomainValidationException
{
    public PhoneNumberValidationException(string message)
        : base(message)
    {
    }
}
