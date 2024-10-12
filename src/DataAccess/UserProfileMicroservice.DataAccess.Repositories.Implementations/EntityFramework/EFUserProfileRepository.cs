using Microsoft.EntityFrameworkCore;
using UserProfileMicroservice.DataAccess.Entities;
using UserProfileMicroservice.DataAccess.EntityFramework;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;

namespace UserProfileMicroservice.DataAccess.Repositories.Implementations.EntityFramework;

public class EFUserProfileRepository(ApplicationDbContext context) : EFRepository<UserProfile, Guid>(context), IUserProfileRepository
{
    public Task<UserProfile?> GetByUsernameAsync(string username)
        => Context.UserProfiles.FirstOrDefaultAsync(x => x.Username.Value.Equals(username));

    public async Task<bool> CanCreateAsync(UserProfile profile)
    => await GetByIdAsync(profile.Id) is null
        && await Context.UserProfiles.FirstOrDefaultAsync(x => x.Email == profile.Email) is null
        && await GetByUsernameAsync(profile.Username.Value) is null;
}

