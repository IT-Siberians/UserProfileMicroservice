using System.ComponentModel.DataAnnotations;
using UserProfileMicroservice.Common.Validation;

namespace UserProfileMicroservice.WebHost.Requests;

public class UpdateProfileRequest
{
    public required Guid Id { get; init; }

    [MaxLength(FirstNameValidationHelper.FirstNameMaximumLength)]
    [RegularExpression(FirstNameValidationHelper.FirstNameCharacterSetPattern)]
    public required string FirstName { get; init; }

    [MaxLength(LastNameValidationHelper.LastNameMaximumLength)]
    [RegularExpression(LastNameValidationHelper.LastNameCharacterSetPattern)]
    public required string LastName { get; init; }

    [Phone]
    public required string? PhoneNumber { get; init; }

    [Url]
    public required string? PhotoUrl { get; init; }

    public required bool IsEmailPublished { get; init; }
    public required bool IsNamePublished { get; init; }
    public required bool IsPhoneNumberPublished { get; init; }
}