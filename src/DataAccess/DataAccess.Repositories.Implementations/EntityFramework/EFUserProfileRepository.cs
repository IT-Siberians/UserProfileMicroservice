using DataAccess.Entities;
using DataAccess.EntityFramework;
using DataAccess.Repositories.Abstractions;

namespace DataAccess.Repositories.Implementations.EntityFramework;

public class EFUserProfileRepository(ApplicationDbContext context) : EFRepository<UserProfile, Guid>(context), IUserProfileRepository
{

}

