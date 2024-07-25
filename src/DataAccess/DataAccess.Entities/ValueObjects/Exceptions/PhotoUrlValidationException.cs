namespace DataAccess.Entities.ValueObjects.Exceptions;

public class PhotoUrlValidationException(string message) : DomainValidationException(message);
