namespace UserProfileMicroservice.WebHost.Responses;

public record PublicProfileResponse(
    string? Email,
    string Username,
    string? FirstName,
    string? LastName,
    string? PhoneNumber,
    string? PhotoUrl);