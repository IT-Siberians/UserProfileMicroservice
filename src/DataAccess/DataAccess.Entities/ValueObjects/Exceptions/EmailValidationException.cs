namespace DataAccess.Entities.ValueObjects.Exceptions;

public class EmailValidationException : Exception
{
    public EmailValidationException(string message)
        : base(message)
    {
    }
}
