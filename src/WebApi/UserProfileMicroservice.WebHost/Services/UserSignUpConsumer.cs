using MassTransit;
using Otus.QueueDto.User;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;
using UserProfileMicroservice.WebHost.Mapping;

namespace UserProfileMicroservice.WebHost.Services;

public class UserSignUpConsumer(IUserProfileService userProfileService) : IConsumer<UserSignUpEvent>
{
    public async Task Consume(ConsumeContext<UserSignUpEvent> context)
    {
        await userProfileService.CreateAsync(context.Message.ToModel());
    }
}
