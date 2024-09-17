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
}
