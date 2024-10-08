using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;
using UserProfileMicroservice.Common.Enumerations;
using UserProfileMicroservice.DataAccess.Entities;
using UserProfileMicroservice.DataAccess.ValueObjects;

namespace UserProfileMicroservice.BusinessLogic.Services.Implementations.Mapping;

internal static class MappingExtensions
{
    public static UserProfileModel MapToModel(this UserProfile profile)
    {
        if (profile is null)
            throw new ArgumentNullException(nameof(profile));

        return new UserProfileModel(
            profile.Id,
            profile.Email.Value,
            profile.Username.Value,
            profile.FirstName.Value,
            profile.LastName.Value,
            profile.PhoneNumber?.Value,
            profile.PhotoUrl?.Value,
            profile.DataPrivacyState);
    }

    public static UserProfile MapToEntity(this UserProfileModel profileModel)
    {
        if (profileModel is null)
            throw new ArgumentNullException(nameof(profileModel));

        var profile = new UserProfile(
            profileModel.Id,
            new Email(profileModel.Email),
            new Username(profileModel.Username),
            new FirstName(profileModel.FirstName),
            new LastName(profileModel.LastName));
        if (profileModel.PhoneNumber is not null)
            profile.ChangePhoneNumber(new PhoneNumber(profileModel.PhoneNumber));
        if (profileModel.PhotoUrl is not null)
            profile.ChangePhotoUrl(new PhotoUrl(profileModel.PhotoUrl));
        profile.ChangeDataPrivacyState(profileModel.DataPrivacyState);
        return profile;

    }

    public static UserProfile MapToEntity(this CreateUserProfileModel profileModel)
    {
        if (profileModel is null)
            throw new ArgumentNullException(nameof(profileModel));

        return new UserProfile(
            profileModel.Id,
            new Email(profileModel.Email),
            new Username(profileModel.Username),
            new FirstName(profileModel.FirstName),
            new LastName(profileModel.LastName));
    }
}
