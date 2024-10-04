namespace UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;
using UserProfileMicroservice.Common.Enumerations;

public record UserProfileModel(
    Guid Id,
    string Email,
    string Username,
    string FirstName,
    string LastName,
    string? PhoneNumber,
    string? PhotoUrl,
    DataPrivacyControlFlags DataPrivacyState)
{
    public bool IsEmailPublished
        => DataPrivacyState.HasFlag(DataPrivacyControlFlags.Email);

    public bool IsFirstNamePublished
        => DataPrivacyState.HasFlag(DataPrivacyControlFlags.FirstName);

    public bool IsLastNamePublished
        => DataPrivacyState.HasFlag(DataPrivacyControlFlags.LastName);

    public bool IsPhoneNumberPublished
        => DataPrivacyState.HasFlag(DataPrivacyControlFlags.PhoneNumber);
}