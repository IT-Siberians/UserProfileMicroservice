using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class Email(string email) : ValueObject<string>(new EmailValidator(), email);
