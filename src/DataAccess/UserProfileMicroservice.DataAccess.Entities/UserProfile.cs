using UserProfileMicroservice.Common.Enumerations;
using UserProfileMicroservice.Common.Extensions;
using UserProfileMicroservice.DataAccess.Entities.Base;
using UserProfileMicroservice.DataAccess.ValueObjects;

namespace UserProfileMicroservice.DataAccess.Entities;

public class UserProfile : Entity<Guid>
{
    public Email Email { get; private set; }
    public Username Username { get; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public PhotoUrl? PhotoUrl { get; private set; }
    public DataPrivacyControlFlags DataPrivacyState { get; private set; }

    public UserProfile(Guid id, Email email, Username username,
        FirstName firstName, LastName lastName,
        DataPrivacyControlFlags dataPrivacyState,
        PhoneNumber? phoneNumber = null, PhotoUrl? photoUrl = null)
        : base(id)
    {
        Id = id;
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Username = username ?? throw new ArgumentNullException(nameof(username));
        FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
        LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        DataPrivacyState = dataPrivacyState;
        PhoneNumber = phoneNumber;
        PhotoUrl = photoUrl;
    }

    public bool ChangeEmail(string emailValue)
    {
        try
        {
            Email = new Email(emailValue);
        }
        catch
        {
            return false;
        }
        return true;
    }

    public void ChangeFirstName(string firstNameValue)
        => FirstName = new FirstName(firstNameValue.ToTitleCase());

    public void ChangeLastname(string lastNameValue)
        => LastName = new LastName(lastNameValue.ToTitleCase());

    public void AddPhoneNumber(string? phoneNumberValue)
    {
        if (PhoneNumber is null && phoneNumberValue is not null)
            ChangePhoneNumber(phoneNumberValue);
    }

    public void ChangePhoneNumber(string? phoneNumberValue)
        => PhoneNumber = phoneNumberValue is null ? null : new PhoneNumber(phoneNumberValue);

    public void AddPhotoUrl(string? photoUrlValue)
    {
        if (PhotoUrl is null && photoUrlValue is not null)
            ChangePhotoUrl(photoUrlValue);
    }

    public void ChangePhotoUrl(string? photoUrlValue)
        => PhotoUrl = photoUrlValue is null ? null : new PhotoUrl(photoUrlValue);

    public void ChangeDataPrivacyState(DataPrivacyControlFlags newDataPrivacyState)
        => DataPrivacyState = newDataPrivacyState;
}
