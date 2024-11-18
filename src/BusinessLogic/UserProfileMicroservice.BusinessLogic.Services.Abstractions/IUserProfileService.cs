using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

namespace UserProfileMicroservice.BusinessLogic.Services.Abstractions;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfileModel>> GetAllAsync();
    Task<UserProfileModel?> GetByIdAsync(Guid id);
    Task<UserProfileModel?> GetByUsernameAsync(string username);
    Task<UserProfileModel?> CreateAsync(CreateUserProfileModel profileModel);
    Task<UserProfileModel?> UpdateAsync(UpdateUserProfileModel updateProfileModel);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ChangeEmailAsync(Guid id, string email);
}
