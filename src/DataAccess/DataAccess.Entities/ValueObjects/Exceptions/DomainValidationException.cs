namespace DataAccess.Entities.ValueObjects.Exceptions;

public class DomainValidationException : Exception
{
    public DomainValidationException(string message)
        : base(message)
    {

    }
}
