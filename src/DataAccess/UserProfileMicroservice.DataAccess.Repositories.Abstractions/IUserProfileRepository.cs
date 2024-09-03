using UserProfileMicroservice.DataAccess.Entities;

namespace UserProfileMicroservice.DataAccess.Repositories.Abstractions;

public interface IUserProfileRepository : IRepository<UserProfile, Guid>
{
}
