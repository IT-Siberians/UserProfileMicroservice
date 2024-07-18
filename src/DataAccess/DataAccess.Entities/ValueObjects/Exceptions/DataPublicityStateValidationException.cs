namespace DataAccess.Entities.ValueObjects.Exceptions;

public class DataPublicityStateValidationException : Exception
{
    public DataPublicityStateValidationException(string message)
        : base(message)
    {
    }
}
