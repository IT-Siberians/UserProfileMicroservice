namespace UserProfileMicroservice.WebHost.Responses;

public record OwnerProfileResponse(
    string Email,
    string Username,
    string FirstName,
    string LastName,
    string? PhoneNumber,
    string? PhotoUrl,
    bool IsEmailPublished,
    bool IsNamePublished,
    bool IsPhoneNumberPublished);