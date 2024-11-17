using MassTransit;
using Otus.QueueDto.User;
using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;
using UserProfileMicroservice.WebHost.Mapping;

namespace UserProfileMicroservice.WebHost.Services;

public class NotificationService(IPublishEndpoint publishEndpoint) : INotificationService
{
    public async Task PublishUserIsCreatedAsync(CreateUserProfileModel createModel)
        => await publishEndpoint.Publish<CreateUserEvent>(createModel.ToEvent());

    public async Task PublishUserIsUpdatedAsync(UserProfileModel updatedModel)
        => await publishEndpoint.Publish<UpdateUserEvent>(updatedModel.ToEvent());
}
