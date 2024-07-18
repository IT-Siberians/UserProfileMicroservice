using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class LastName : ValueObject<string>
{
    public LastName(string lastName)
        : base(new LastNameValidator(), lastName)
    {
    }
    }
