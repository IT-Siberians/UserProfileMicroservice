using System.ComponentModel.DataAnnotations;
using UserProfileMicroservice.Common.Validation;

namespace UserProfileMicroservice.WebHost.Requests;

public record UpdateProfileRequest(
    Guid Id,
    [MaxLength(FirstNameValidationHelper.FirstNameMaximumLength)]
    [RegularExpression(FirstNameValidationHelper.FirstNameCharacterSetPattern)]
    string FirstName,
    [MaxLength(LastNameValidationHelper.LastNameMaximumLength)]
    [RegularExpression(LastNameValidationHelper.LastNameCharacterSetPattern)]
    string LastName,
    [Phone]
    string? PhoneNumber,
    [Url]
    string? PhotoUrl,
    bool IsEmailPublished,
    bool IsNamePublished,
    bool IsPhoneNumberPublished);