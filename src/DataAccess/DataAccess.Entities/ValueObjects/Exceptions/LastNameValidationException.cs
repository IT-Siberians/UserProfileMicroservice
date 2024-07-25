namespace DataAccess.Entities.ValueObjects.Exceptions;

public class LastNameValidationException(string message) : DomainValidationException(message);
