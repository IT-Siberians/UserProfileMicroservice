namespace DataAccess.Entities.ValueObjects.Exceptions;

public class LastNameValidationException : DomainValidationException
{
    public LastNameValidationException(string message)
        : base(message)
    {
    }
}
