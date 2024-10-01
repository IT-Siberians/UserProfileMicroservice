using UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;
using UserProfileMicroservice.Common.Enumerations;
using UserProfileMicroservice.DataAccess.Entities;

namespace UserProfileMicroservice.BusinessLogic.Services.Implementations.Mapping;

internal static class MappingExtensions
{
    public static UserProfileModel MapToModel(this UserProfile profile)
    {
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
            isEmailPublished,
            isFirstNamePublished,
            isLastNamePublished,
            isPhoneNumberPublished);
    }

    public static UserProfile MapToEntity(this UserProfileModel profileModel)
    {
        var dataPrivacyState = DataPrivacyControlFlags.CompletePrivacy;
        if (profileModel.IsEmailPublished)
            dataPrivacyState |= DataPrivacyControlFlags.Email;
        if (profileModel.IsFirstNamePublished)
            dataPrivacyState |= DataPrivacyControlFlags.FirstName;
        if (profileModel.IsLastNamePublished)
            dataPrivacyState |= DataPrivacyControlFlags.LastName;
        if (profileModel.IsPhoneNumberPublished)
            dataPrivacyState |= DataPrivacyControlFlags.PhoneNumber;
        return new UserProfile(
            profileModel.Id,
            profileModel.Email,
            profileModel.Username,
            profileModel.FirstName,
            profileModel.LastName,
            profileModel.PhoneNumber,
            profileModel.PhotoUrl,
            dataPrivacyState);
    }
}
