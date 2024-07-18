namespace DataAccess.Entities;

[Flags]
public enum PublicDataFlags
{
    Email,
    FirstName,
    LastName,
    PhoneNumber,
    // This enumeration member must always be the last.
    MaximumValue
}
