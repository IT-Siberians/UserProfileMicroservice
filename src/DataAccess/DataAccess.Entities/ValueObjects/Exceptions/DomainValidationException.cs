namespace DataAccess.Entities.ValueObjects.Exceptions;

public class DomainValidationException(string message) : Exception(message);
