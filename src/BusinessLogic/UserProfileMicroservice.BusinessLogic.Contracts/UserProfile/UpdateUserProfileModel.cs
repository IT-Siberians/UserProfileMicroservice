using UserProfileMicroservice.Common.Enumerations;

namespace UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

public record UpdateUserProfileModel(
    Guid Id,
    string FirstName,
    string LastName,
    string? PhoneNumber,
    string? PhotoUrl,
    DataPrivacyControlFlags DataPrivacyState)
    : IUserProfileModel;
