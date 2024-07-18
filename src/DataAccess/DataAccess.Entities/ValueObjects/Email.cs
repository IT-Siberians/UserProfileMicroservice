using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class Email : ValueObject<string>
{
    public Email(string email)
        : base(new EmailValidator(), email)
    {
    }

}
