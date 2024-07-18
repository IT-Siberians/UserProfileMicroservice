using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class Username : ValueObject<string>
{
    public Username(string name)
        : base(new UsernameValidator(), name)
    {
    }
}
