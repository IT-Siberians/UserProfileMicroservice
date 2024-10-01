namespace UserProfileMicroservice.Common.Enumerations;

[Flags]
public enum DataPrivacyControlFlags
{
    CompletePrivacy = 0,
    Email = 0X0001,
    FirstName = 0X0002,
    LastName = 0X0004,
    PhoneNumber = 0X0008,
}
