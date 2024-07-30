using DataAccess.Entities.ValueObjects.Base;
using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class Username(string username) : ValueObject<string>(new UsernameValidator(), username);
