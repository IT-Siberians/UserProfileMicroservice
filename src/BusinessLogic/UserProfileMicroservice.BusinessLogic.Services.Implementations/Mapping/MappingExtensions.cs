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

        bool isEmailPublished = profile.DataPrivacyState.HasFlag(DataPrivacyControlFlags.Email);
        bool isFirstNamePublished = profile.DataPrivacyState.HasFlag(DataPrivacyControlFlags.FirstName);
        bool isLastNamePublished = profile.DataPrivacyState.HasFlag(DataPrivacyControlFlags.LastName);
        bool isPhoneNumberPublished = profile.DataPrivacyState.HasFlag(DataPrivacyControlFlags.PhoneNumber);
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

        return new UserProfile(
            profileModel.Id,
            new Email(profileModel.Email),
            new Username(profileModel.Username),
            new FirstName(profileModel.FirstName),
            new LastName(profileModel.LastName),
            profileModel.PhoneNumber is null ? null : new PhoneNumber(profileModel.PhoneNumber),
            profileModel.PhotoUrl is null ? null : new PhotoUrl(profileModel.PhotoUrl),
            profileModel.DataPrivacyState);
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
            new LastName(profileModel.LastName),
            null,
            null,
            DataPrivacyControlFlags.CompletePrivacy);
    }
}
