using Microsoft.EntityFrameworkCore;
using UserProfileMicroservice.DataAccess.Entities;
using UserProfileMicroservice.DataAccess.EntityFramework;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;

namespace UserProfileMicroservice.DataAccess.Repositories.Implementations.EntityFramework;

public class EFUserProfileRepository(ApplicationDbContext context) : EFRepository<UserProfile, Guid>(context), IUserProfileRepository
{
    public async Task<UserProfile?> GetByUsernameAsync(string username)
    {
        var profiles = await GetAllAsync();
        return profiles.FirstOrDefault(x => x.Username.Value.Equals(username));
    }

    public async Task<bool> CanCreateAsync(UserProfile profile)
        => await GetByIdAsync(profile.Id) is null
        && !await Context.UserProfiles.AnyAsync(x => x.Email == profile.Email)
        && await GetByUsernameAsync(profile.Username.Value) is null;
}

