namespace UserProfileMicroservice.BusinessLogic.Contracts.UserProfile;

public  interface IUserProfileModel
{
    Guid Id { get; init; }
    string FirstName { get; init; }
    string LastName { get; init; }
}
