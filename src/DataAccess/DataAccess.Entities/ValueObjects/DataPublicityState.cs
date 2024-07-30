using DataAccess.Entities.ValueObjects.Base;
using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public   class DataPublicityState(int state) : ValueObject<int>(new DataPublicityValidator(), state);
