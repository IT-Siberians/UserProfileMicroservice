using UserProfileMicroservice.Common.Enumerations;

namespace UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

public record UserProfileModel(
    Guid Id,
    string Email,
    string Username,
    string FirstName,
    string LastName,
    string? PhoneNumber,
    string? PhotoUrl,
    DataPrivacyControlFlags DataPrivacyState);