namespace DataAccess.Entities.ValueObjects.Exceptions;

public class LastNameValidationException : Exception
{
    public LastNameValidationException(string message)
        : base(message)
    {
    }
}
