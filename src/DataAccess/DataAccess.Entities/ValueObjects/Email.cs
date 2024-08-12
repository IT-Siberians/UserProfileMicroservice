﻿using DataAccess.Entities.ValueObjects.Base;
using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class Email(string email) : ValueObject<string>(new EmailValidator(), email)
{
    public const int MaximumValueLength = 255;
}
