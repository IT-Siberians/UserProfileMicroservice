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

    public void ChangeFirstName(FirstName? newFirstName)
    {
        FirstName = newFirstName;
    }

    public void ChangeLastname(LastName? newLastName)
    {
        LastName = newLastName;
    }

    public void ChangePhoneNumber(PhoneNumber? newPhoneNumber)
    {
        PhoneNumber = newPhoneNumber;
    }

    public void ChangePhotoUrl(PhotoUrl? newPhotoUrl)
    {
        PhotoUrl = newPhotoUrl;
    }

    public void ChangeDataPublicityState(DataPublicityState newDataPublicityState)
    {
        DataPublicityState = DataPublicityState;
    }
}
