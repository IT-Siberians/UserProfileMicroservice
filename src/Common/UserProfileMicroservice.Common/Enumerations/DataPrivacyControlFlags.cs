namespace UserProfileMicroservice.Common.Enumerations;

/// <summary>
/// Bit mask controlling the accessibility for other users to view the corresponding data.
/// The values are the degree of the number two.
/// If the flag is set, the corresponding data is available for viewing by other users.
/// </summary>
[Flags]
public enum DataPrivacyControlFlags
{
    // All data is hidden for viewing. Default value for new users.
    CompletePrivacy = 0,
    Email = 0B00000001,
    FirstName = 0B00000010,
    LastName = 0B00000100,
    PhoneNumber = 0B0001000,
}
