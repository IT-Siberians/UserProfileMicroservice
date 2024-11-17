using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;
using UserProfileMicroservice.BusinessLogic.Services.Abstractions;
using UserProfileMicroservice.BusinessLogic.Services.Implementations.Mapping;
using UserProfileMicroservice.Common.Extensions;
using UserProfileMicroservice.DataAccess.Repositories.Abstractions;

namespace UserProfileMicroservice.BusinessLogic.Services.Implementations;

public class UserProfileService(IUserProfileRepository userProfileRepository, INotificationService notificationService) : IUserProfileService
{
    public async Task<UserProfileModel?> CreateAsync(CreateUserProfileModel createProfileModel)
    {
        var createProfile = createProfileModel.ToEntity();
        if (!await userProfileRepository.CanCreateAsync(createProfile))
            return null;
        await userProfileRepository.AddAsync(createProfile);
        await notificationService.PublishUserIsCreatedAsync(createProfileModel);

        return createProfile.ToModel();
    }

    public async Task<bool> DeleteAsync(Guid id)
        => await userProfileRepository.DeleteAsync(id);

    public async Task<IEnumerable<UserProfileModel>> GetAllAsync()
        => (await userProfileRepository.GetAllAsync()).Select(x => x.ToModel());

    public async Task<UserProfileModel?> GetByIdAsync(Guid id)
    {
        var profile = await userProfileRepository.GetByIdAsync(id);
        return profile?.ToModel();
    }

    public async Task<UserProfileModel?> GetByUsernameAsync(string username)
    {
        var profile = await userProfileRepository.GetByUsernameAsync(username);
        return profile?.ToModel();
    }

    public async Task<UserProfileModel?> UpdateAsync(UpdateUserProfileModel updateProfileModel)
    {
        if (updateProfileModel is null)
            return null;
        var profile = await userProfileRepository.GetByIdAsync(updateProfileModel.Id);
        if (profile is null)
            return null;

        profile.ChangeFirstName(updateProfileModel.FirstName);
        profile.ChangeLastname(updateProfileModel.LastName);
        profile.ChangePhoneNumber(updateProfileModel.PhoneNumber);
        profile.ChangePhotoUrl(updateProfileModel.PhotoUrl);
        profile.ChangeDataPrivacyState(updateProfileModel.DataPrivacyState);

        if (!await userProfileRepository.UpdateAsync(profile))
            return null;
        await notificationService.PublishUserIsUpdatedAsync(profile.ToModel());
        return profile.ToModel();
    }

    public async Task<UserProfileModel?> ChangeEmailAsync(Guid id, string email)
    {
        var profile = await userProfileRepository.GetByIdAsync(id);
        if (profile is null)
            return null;

        if (!email.IsEmailAddress())
            return null;

        profile.ChangeEmail(email);

        if (!await userProfileRepository.UpdateAsync(profile))
            return null;
        await notificationService.PublishUserIsUpdatedAsync(profile.ToModel());
        return profile.ToModel();
    }

}
