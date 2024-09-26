using UserProfileMicroservice.BusinessLogic.Contracts.Base;

namespace UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

public record PublicUserProfileModel(Guid Id, string Email, string Username,
    string? FirstName, string? LastName, string? PhoneNumber, string? PhotoUrl)
    : IModel<Guid>;

