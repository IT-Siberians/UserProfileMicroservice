using UserProfileMicroservice.DataAccess.Entities;

namespace UserProfileMicroservice.DataAccess.Repositories.Abstractions;

public interface IUserProfileRepository : IRepository<UserProfile, Guid>
{
    Task<UserProfile?> GetByUsernameAsync(string username);
    Task<bool> CanCreateAsync(UserProfile profile);
}
