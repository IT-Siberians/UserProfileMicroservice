namespace DataAccess.Entities.ValueObjects.Exceptions;

public class UsernameValidationException(string message) : DomainValidationException(message);
