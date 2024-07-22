namespace DataAccess.Entities.ValueObjects.Exceptions;

public class DataPublicityStateValidationException : DomainValidationException
{
    public DataPublicityStateValidationException(string message)
        : base(message)
    {
    }
}
