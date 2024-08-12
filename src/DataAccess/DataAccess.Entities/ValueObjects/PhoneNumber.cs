using DataAccess.Entities.ValueObjects.Base;
using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class PhoneNumber(string phoneNumber) : ValueObject<string>(new PhoneNumberValidator(), phoneNumber)
{
    public const int MaximumValueLength = 14;
}
