using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

namespace UserProfileMicroservice.BusinessLogic.Services.Abstractions;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfileModel>> GetAllAsync();
    Task<UserProfileModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<UserProfileModel?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<UserProfileModel?> CreateAsync(CreateUserProfileModel profileModel);
    Task<UserProfileModel?> UpdateAsync(UpdateUserProfileModel updateProfileModel, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> ChangeEmailAsync(Guid id, string email);
}
