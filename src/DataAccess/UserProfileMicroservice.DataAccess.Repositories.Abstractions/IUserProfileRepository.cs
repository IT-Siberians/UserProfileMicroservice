using UserProfileMicroservice.DataAccess.Entities;

namespace UserProfileMicroservice.DataAccess.Repositories.Abstractions;

public interface IUserProfileRepository : IRepository<UserProfile, Guid>
{
    Task<UserProfile?> GetByUsernameAsync(string username, CancellationToken cancellationToken);
    Task<bool> CanCreateAsync(UserProfile profile);
}
