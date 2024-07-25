namespace DataAccess.Entities.ValueObjects.Exceptions;

public class EmailValidationException(string message) : DomainValidationException(message);
