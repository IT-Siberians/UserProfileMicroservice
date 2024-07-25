namespace DataAccess.Entities.ValueObjects.Exceptions;

public class FirstNameValidationException(string message) : DomainValidationException(message);
