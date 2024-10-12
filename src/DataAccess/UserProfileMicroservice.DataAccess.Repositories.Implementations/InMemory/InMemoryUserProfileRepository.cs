using UserProfileMicroservice.DataAccess.Entities;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;

namespace UserProfileMicroservice.DataAccess.Repositories.Implementations.InMemory;

public class InMemoryUserProfileRepository(IEnumerable<UserProfile> userProfiles)
    : InMemoryRepository<UserProfile, Guid>(userProfiles), IUserProfileRepository
{
    public InMemoryUserProfileRepository()
        : this([])
    {
    }

    public Task<UserProfile?> GetByUsernameAsync(string username)
        => Task.FromResult(EntityList.FirstOrDefault(x => x.Username.Value.Equals(username)));

    public async Task<bool> CanCreateAsync(UserProfile profile)
        => await GetByIdAsync(profile.Id) is null
        && EntityList.FirstOrDefault(x => x.Email == profile.Email) is null
        && await GetByUsernameAsync(profile.Username.Value) is null;
}
