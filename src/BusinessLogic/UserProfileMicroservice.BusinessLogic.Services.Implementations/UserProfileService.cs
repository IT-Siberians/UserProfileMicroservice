using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;
using UserProfileMicroservice.BusinessLogic.Services.Implementations.Mapping;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;

namespace UserProfileMicroservice.BusinessLogic.Services.Implementations;

public class UserProfileService(IUserProfileRepository userProfileRepository) : IUserProfileService
{
    public async Task<UserProfileModel?> CreateUserProfileAsync(CreateUserProfileModel createProfileModel)
    {
        var createProfile = createProfileModel.MapToEntity();
        if (!await userProfileRepository.CanCreateUserProfileAsync(createProfile))
            return null;
        await userProfileRepository.AddAsync(createProfile);
        return createProfile.MapToModel();
    }

    public Task DeleteUserProfileAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserProfileModel>> GetAllUserProfilesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserProfileModel?> GetUserProfileByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserProfileModel?> GetUserProfileByUsernameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserProfileAsync(UserProfileModel userProfile)
    {
        throw new NotImplementedException();
    }
}
