namespace DataAccess.Entities.ValueObjects.Exceptions;

public class PhoneNumberValidationException(string message) : DomainValidationException(message);
