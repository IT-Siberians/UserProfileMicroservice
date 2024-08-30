


using DataAccess.Entities.ValueObjects.Base;
using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class FirstName(string firstName) : ValueObject<String>(new FirstNameValidator(), firstName)
{
    public const int MaximumValueLength = 30;
}
