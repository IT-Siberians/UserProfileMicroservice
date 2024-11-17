using MassTransit;
using Otus.QueueDto.User;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;

namespace UserProfileMicroservice.WebHost.Services;

public class EmailChangedConsumer(IUserProfileService userProfileService) : IConsumer<EmailChangedEvent>
{
    public async Task Consume(ConsumeContext<EmailChangedEvent> context)
        => await userProfileService.ChangeEmailAsync(context.Message.Id, context.Message.ChangedEmail);
}
