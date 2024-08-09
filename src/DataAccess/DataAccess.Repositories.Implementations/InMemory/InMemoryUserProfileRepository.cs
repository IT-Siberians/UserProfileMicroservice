using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;

namespace DataAccess.Repositories.Implementations.InMemory;

public class InMemoryUserProfileRepository(IEnumerable<UserProfile> userProfiles)
    : InMemoryRepository<UserProfile, Guid>(userProfiles), IUserProfileRepository
{
    public InMemoryUserProfileRepository()
            : this([])
    {

    }
}
