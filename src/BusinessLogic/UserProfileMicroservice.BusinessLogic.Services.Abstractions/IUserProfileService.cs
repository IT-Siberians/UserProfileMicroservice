using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

namespace UserProfileMicroservice.BusinessLogic.Services.Abstractions;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfileModel>> GetAllAsync();
    Task<UserProfileModel?> GetByIdAsync(Guid id);
    Task<UserProfileModel?> GetByUsernameAsync(string name);
    Task<UserProfileModel?> CreateAsync(CreateUserProfileModel UserProfile);
    Task UpdateAsync(UserProfileModel userProfile);
    Task DeleteAsync(Guid id);
}
