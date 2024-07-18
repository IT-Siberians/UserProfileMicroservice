using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class PhoneNumber : ValueObject<string>
{
    public PhoneNumber(string phoneNumber)
        : base(new PhoneNumberValidator(), phoneNumber)
    {
    }
}
