using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

namespace UserProfileMicroservice.BusinessLogic.Services.Abstractions;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfileModel>> GetAllUserProfilesAsync();
    Task<UserProfileModel?> GetUserProfileByIdAsync(Guid id);
    Task<UserProfileModel?> GetUserProfileByUsernameAsync(string name);
    Task<UserProfileModel?> CreateUserProfileAsync(CreateUserProfileModel UserProfile);
    Task UpdateUserProfileAsync(UserProfileModel userProfile);
    Task DeleteUserProfileAsync(Guid id);
}
