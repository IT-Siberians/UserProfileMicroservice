namespace DataAccess.Entities.ValueObjects.Exceptions;

public class DataPublicityStateValidationException(string message) : DomainValidationException(message);
