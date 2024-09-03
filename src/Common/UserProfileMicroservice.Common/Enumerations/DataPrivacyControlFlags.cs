namespace UserProfileMicroservice.Common.Enumerations;

[Flags]
public enum DataPrivacyControlFlags
{
    Email,
    FirstName,
    LastName,
    PhoneNumber,
}
