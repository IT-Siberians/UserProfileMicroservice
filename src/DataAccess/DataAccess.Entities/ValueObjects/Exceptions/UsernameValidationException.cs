namespace DataAccess.Entities.ValueObjects.Exceptions;

public class UsernameValidationException : DomainValidationException
{
    public UsernameValidationException(string message)
        : base(message)
    {
    }
}
