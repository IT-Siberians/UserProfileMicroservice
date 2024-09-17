using UserProfileMicroservice.DataAccess.Entities;
using UserProfileMicroservice.DataAccess.EntityFramework;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;

namespace UserProfileMicroservice.DataAccess.Repositories.Implementations.EntityFramework;

public class EFUserProfileRepository(ApplicationDbContext context) : EFRepository<UserProfile, Guid>(context), IUserProfileRepository
{

}

