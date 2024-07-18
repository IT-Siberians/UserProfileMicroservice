using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class FirstName : ValueObject<String>
{
    public FirstName(string firstName)
        : base(new FirstNameValidator(), firstName)
    {
    }
    }
