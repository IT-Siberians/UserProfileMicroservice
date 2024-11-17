using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

namespace UserProfileMicroservice.BusinessLogic.Services.Abstractions;

public interface INotificationService
{
    Task PublishUserIsCreatedAsync(CreateUserProfileModel createModel);
    Task PublishUserIsUpdatedAsync(UserProfileModel updatedModel);
}
