using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;

namespace UserProfileMicroservice.BusinessLogic.Services.Implementations;

public class UserProfileService : IUserProfileService
{
    public Task<UserProfileModel?> CreateUserProfileAsync(CreateUserProfileModel UserProfile)
    {
        throw new NotImplementedException();
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
