namespace UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

public record UserProfileModel(
    Guid Id,
    string Email,
    string Username,
    string FirstName,
    string LastName,
    string? PhoneNumber,
    string? PhotoUrl,
    bool IsEmailPublished,
    bool IsFirstNamePublished,
    bool IsLastNamePublished,
    bool IsPhoneNumberPublished);