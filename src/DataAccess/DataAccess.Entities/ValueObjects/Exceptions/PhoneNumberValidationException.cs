namespace DataAccess.Entities.ValueObjects.Exceptions;

public class PhoneNumberValidationException : Exception
{
    public PhoneNumberValidationException(string message)
        : base(message)
    {
    }
}
