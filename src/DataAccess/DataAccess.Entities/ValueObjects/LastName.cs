using DataAccess.Entities.ValueObjects.Base;
using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class LastName(string lastName) : ValueObject<string>(new LastNameValidator(), lastName);
