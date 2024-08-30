using DataAccess.Entities.Base;
using DataAccess.Entities.ValueObjects;

namespace DataAccess.Entities;

public class UserProfile : Entity<Guid>
{
    public Email Email { get; }
    public Username Username { get; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public PhotoUrl? PhotoUrl { get; private set; }
    public DataPublicityState DataPublicityState { get; private set; }

    public UserProfile(Guid id, Email email, Username username, FirstName firstName, LastName lastName,
        PhoneNumber phoneNumber, PhotoUrl photoUrl, DataPublicityState dataPublicityState)
        : base(id)
    {
        Id = id;
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Username = username ?? throw new ArgumentNullException(nameof(username));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        PhoneNumber = phoneNumber;
        PhotoUrl = photoUrl;
        DataPublicityState = dataPublicityState ?? throw new ArgumentNullException(nameof(dataPublicityState));
    }

    public void ChangeFirstName(FirstName? newFirstName)
    {
        FirstName = newFirstName ?? throw new ArgumentNullException(nameof(newFirstName));
    }

    public void ChangeLastname(LastName? newLastName)
    {
        LastName = newLastName ?? throw new ArgumentNullException(nameof(newLastName));
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
        DataPublicityState = DataPublicityState ?? throw new ArgumentNullException(nameof(DataPublicityState));
    }
}
