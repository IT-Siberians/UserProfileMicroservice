using UserProfileMicroservice.Common.Enumerations;
using UserProfileMicroservice.DataAccess.Entities.Base;
using UserProfileMicroservice.DataAccess.ValueObjects;

namespace UserProfileMicroservice.DataAccess.Entities;

public class UserProfile : Entity<Guid>
{
    public Email Email { get; }
    public Username Username { get; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public PhotoUrl? PhotoUrl { get; private set; }
    public DataPrivacyControlFlags DataPrivacyState { get; private set; }

    public UserProfile(Guid id, Email email, Username username, FirstName firstName, LastName lastName,
        PhoneNumber? phoneNumber = null, PhotoUrl? photoUrl = null, DataPrivacyControlFlags dataPrivacyState = DataPrivacyControlFlags.CompletePrivacy)
        : base(id)
    {
        Id = id;
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Username = username ?? throw new ArgumentNullException(nameof(username));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        PhoneNumber = phoneNumber;
        PhotoUrl = photoUrl;
        DataPrivacyState = dataPrivacyState;
    }

    public void ChangeFirstName(FirstName newFirstName)
        => FirstName = newFirstName ?? throw new ArgumentNullException(nameof(newFirstName));

    public void ChangeLastname(LastName newLastName)
        => LastName = newLastName ?? throw new ArgumentNullException(nameof(newLastName));

    public void ChangePhoneNumber(PhoneNumber? newPhoneNumber)
        => PhoneNumber = newPhoneNumber;

    public void ChangePhotoUrl(PhotoUrl? newPhotoUrl)
        => PhotoUrl = newPhotoUrl;

    public void ChangeDataPrivacyState(DataPrivacyControlFlags newDataPrivacyState)
        => DataPrivacyState = newDataPrivacyState;
}
