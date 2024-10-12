using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

namespace UserProfileMicroservice.BusinessLogic.Services.Abstractions;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfileModel>> GetAllAsync();
    Task<UserProfileModel?> GetByIdAsync(Guid id);
    Task<UserProfileModel?> GetByUsernameAsync(string username);
    Task<UserProfileModel?> CreateAsync(CreateUserProfileModel profileModel);
    Task<bool> UpdateAsync(UserProfileModel profileModel);
    Task<bool> DeleteAsync(Guid id);
}
