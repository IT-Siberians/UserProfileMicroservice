using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;
using UserProfileMicroservice.Common.Utils;
using UserProfileMicroservice.WebHost.Requests;
using UserProfileMicroservice.WebHost.Responses;
using Otus.QueueDto.User;

namespace UserProfileMicroservice.WebHost.Mapping;

internal static class MappingExtensions
{
    public static CreateUserProfileModel ToModel(this CreateProfileRequest createProfileRequest)
    {
        var dataPrivacyConfigurator = new DataPrivacyConfigurator();
        dataPrivacyConfigurator.IsEmailPublished = createProfileRequest.IsEmailPublished;
        dataPrivacyConfigurator.IsNamePublished = createProfileRequest.IsNamePublished;
        dataPrivacyConfigurator.IsPhoneNumberPublished = createProfileRequest.IsPhoneNumberPublished;
        return new CreateUserProfileModel(
            createProfileRequest.Id,
            createProfileRequest.Email,
            createProfileRequest.Username,
            createProfileRequest.FirstName,
            createProfileRequest.LastName,
            createProfileRequest.PhoneNumber,
            createProfileRequest.PhotoUrl,
            dataPrivacyConfigurator.GetDataPrivacyState());
    }

    public static UpdateUserProfileModel ToModel(this UpdateProfileRequest updateProfileRequest)
    {
        var dataPrivacyConfigurator = new DataPrivacyConfigurator();
        dataPrivacyConfigurator.IsEmailPublished = updateProfileRequest.IsEmailPublished;
        dataPrivacyConfigurator.IsNamePublished = updateProfileRequest.IsNamePublished;
        dataPrivacyConfigurator.IsPhoneNumberPublished = updateProfileRequest.IsPhoneNumberPublished;
        return new UpdateUserProfileModel(
            updateProfileRequest.Id,
            updateProfileRequest.FirstName,
            updateProfileRequest.LastName,
            updateProfileRequest.PhoneNumber,
            updateProfileRequest.PhotoUrl,
            dataPrivacyConfigurator.GetDataPrivacyState());
    }

    public static OwnerProfileResponse ToResponse(this UserProfileModel profileModel)
    {
        var dataPrivacyConfigurator = new DataPrivacyConfigurator(profileModel.DataPrivacyState);

        return new OwnerProfileResponse(
            profileModel.Email,
            profileModel.Username,
            profileModel.FirstName,
            profileModel.LastName,
            profileModel.PhoneNumber,
            profileModel.PhotoUrl,
            dataPrivacyConfigurator.IsEmailPublished,
            dataPrivacyConfigurator.IsNamePublished,
            dataPrivacyConfigurator.IsPhoneNumberPublished);
    }

    public static PublicProfileResponse ToPublicResponse(this UserProfileModel profileModel)
    {
        var dataPrivacyConfigurator = new DataPrivacyConfigurator(profileModel.DataPrivacyState);

        return new PublicProfileResponse(
            dataPrivacyConfigurator.IsEmailPublished ? profileModel.Email : null,
            profileModel.Username,
            dataPrivacyConfigurator.IsNamePublished ? profileModel.FirstName : null,
            dataPrivacyConfigurator.IsNamePublished ? profileModel.LastName : null,
            dataPrivacyConfigurator.IsPhoneNumberPublished ? profileModel.PhoneNumber : null,
            profileModel.PhotoUrl);
    }

    public static CreateUserEvent ToEvent(this CreateUserProfileModel profileModel)
    {
        return new CreateUserEvent(
            profileModel.Id,
            profileModel.Username,
            $"{profileModel.FirstName} {profileModel.LastName}",
            profileModel.Email,
            String.Empty);
    }

    public static UpdateUserEvent ToEvent(this UserProfileModel profileModel)
    {
        return new UpdateUserEvent(
            profileModel.Id,
            profileModel.Username,
            $"{profileModel.FirstName} {profileModel.LastName}",
            profileModel.Email);
    }
}
