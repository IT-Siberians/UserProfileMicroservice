using DataAccess.Entities.ValueObjects;

namespace DataAccess.Entities;

public class UserProfile
{
    public Guid UserId { get; }
    public Email Email { get; }
    public Username Username { get; }
    public FirstName? FirstName { get; private set; }
    public LastName? LastName { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public PhotoUrl? PhotoUrl { get; private set; }
    public DataPublicityState DataPublicityState { get; private set; }

    public UserProfile(Guid userId, Email email, Username username, FirstName firstName, LastName lastName, PhoneNumber phoneNumber, PhotoUrl photoUrl, DataPublicityState dataPublicityState)
    {
        UserId = userId;
        Email = email;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        PhotoUrl = photoUrl;
        DataPublicityState = dataPublicityState;
    }   

    public bool ChangeFirstName(FirstName? newFirstName)
    {
        FirstName = newFirstName;
        return true;
    }

    public bool ChangeLastname(LastName? newLastName)
    {
        LastName = newLastName;
        return true;
    }

    public bool ChangePhoneNumber(PhoneNumber? newPhoneNumber)
    {
        PhoneNumber = newPhoneNumber;
        return true;
    }

    public bool ChangePhotoUrl(PhotoUrl? newPhotoUrl)
    {
        PhotoUrl = newPhotoUrl;
        return true;
    }

    public bool ChangeDataPublicityState(DataPublicityState newDataPublicityState)
    {
        DataPublicityState = DataPublicityState;
        return true;
    }
}
