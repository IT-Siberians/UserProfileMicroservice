namespace UserProfileMicroservice.Common.Enumerations;

// Bit mask controlling the accessibility for other users to view the corresponding data.
// The values are the degree of the number two.
// If the flag is set, the corresponding data is available for viewing by other users.
[Flags]
public enum DataPrivacyControlFlags
{
    // All data is hidden for viewing. Default value for new users.
    CompletePrivacy = 0,
    Email = 0X0001,
    FirstName = 0X0002,
    LastName = 0X0004,
    PhoneNumber = 0X0008,
}
