namespace DataAccess.Entities.ValueObjects.Exceptions;

public class FirstNameValidationException : Exception
{
    public FirstNameValidationException(string message)
        : base(message)
    {
    }
}
