namespace DataAccess.Entities.ValueObjects.Exceptions;

public class UsernameValidationException : Exception
{
    public UsernameValidationException(string message)
        : base(message)
    {
    }
}
