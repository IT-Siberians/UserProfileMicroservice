namespace DataAccess.Entities.ValueObjects.Exceptions;

public class EmailValidationException : DomainValidationException
{
    public EmailValidationException(string message)
        : base(message)
    {
    }
}
