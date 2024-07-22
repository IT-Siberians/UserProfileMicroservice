namespace DataAccess.Entities.ValueObjects.Exceptions;

public class FirstNameValidationException : DomainValidationException
{
    public FirstNameValidationException(string message)
        : base(message)
    {
    }
}
