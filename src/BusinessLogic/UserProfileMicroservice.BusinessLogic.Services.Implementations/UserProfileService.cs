using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;
using UserProfileMicroservice.BusinessLogic.Services.Implementations.Mapping;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;

namespace UserProfileMicroservice.BusinessLogic.Services.Implementations;

public class UserProfileService(IUserProfileRepository userProfileRepository) : IUserProfileService
{
    public async Task<UserProfileModel?> CreateAsync(CreateUserProfileModel createProfileModel)
    {
        var createProfile = createProfileModel.MapToEntity();
        if (!await userProfileRepository.CanCreateAsync(createProfile))
            return null;
        await userProfileRepository.AddAsync(createProfile);
        return createProfile.MapToModel();
    }

    public async Task<bool> DeleteAsync(Guid id)
        => await userProfileRepository.DeleteAsync(id);

    public async Task<IEnumerable<UserProfileModel>> GetAllAsync()
        => (await userProfileRepository.GetAllAsync()).Select(x => x.MapToModel());

    public async Task<UserProfileModel?> GetByIdAsync(Guid id)
    {
        var profile = await userProfileRepository.GetByIdAsync(id);
        return profile is null ? null : profile.MapToModel();
    }

    public async Task<UserProfileModel?> GetByUsernameAsync(string username)
    {
        var profile = await userProfileRepository.GetByUsernameAsync(username);
        return profile is null ? null : profile.MapToModel();
    }

    public async Task<bool> UpdateAsync(UserProfileModel profileModel)
    {
        if (profileModel is null)
            return false;
        var profile = await userProfileRepository.GetByIdAsync(profileModel.Id);
        if (profile is null)
            return false;
        return await userProfileRepository.UpdateAsync(profileModel.MapToEntity());
    }
}
