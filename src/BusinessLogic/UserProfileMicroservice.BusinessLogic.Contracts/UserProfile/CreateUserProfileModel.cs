namespace UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

public record CreateUserProfileModel(
    Guid Id,
    string Email,
    string Username,
    string FirstName,
    string LastName);