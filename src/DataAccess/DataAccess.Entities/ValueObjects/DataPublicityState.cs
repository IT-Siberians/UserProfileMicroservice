using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public   class DataPublicityState : ValueObject<int>
{
    public DataPublicityState(int state)
        : base(new DataPublicityValidator(), state)
    {

    }
}
