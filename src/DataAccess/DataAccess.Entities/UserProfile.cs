namespace DataAccess.Entities;

public class UserProfile
{
    public Guid UserId { get; }
    public Email Email { get; }
    public Username Username { get; }
    public Firstname? Firstname { get; private set; }
    public Lastname? Lastname { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public PhotoUrl? PhotoUrl { get; private set; }
    public PublicDataFlags PublicDataFlags { get; private set; }

    public UserProfile(Guid userId, Email email, Username username, Firstname firstname, Lastname lastname, PhoneNumber phoneNumber, PhotoUrl photoUrl, PublicDataFlags publicDataFlags)
    {
        UserId = userId;
        Email = email;
        Username = username;
        Firstname = firstname;
        Lastname = lastname;
        PhoneNumber = phoneNumber;
        PhotoUrl = photoUrl;
        PublicDataFlags = publicDataFlags;
    }   

    public bool ChangeFirstname(string newFirstname)
    {
        try
        {
            var firstname = new Firstname(newFirstname);
            Firstname = firstname;
        }
        catch (ArgumentException)
        {
            return false;
        }
        return true;
    }

    public bool ChangeLastname(string newLastname)
    {
        try
        {
            var lastname = new Lastname(newLastname);
            Lastname = lastname;
        }
        catch (ArgumentException)
        {
            return false;
        }
        return true;
    }

    public bool ChangePhoneNumber(string newPhoneNumber)
    {
        try
        {
            var phoneNumber = new PhoneNumber(newPhoneNumber);
            PhoneNumber = phoneNumber;
        }
        catch (ArgumentException)
        {
            return false;
        }
        return true;
    }

    public bool ChangePhotoUrl(string newPhotoUrl)
    {
        try
        {
            var photoUrl = new PhotoUrl(newPhotoUrl);
            PhotoUrl = photoUrl;
        }
        catch (ArgumentException)
        {
            return false;
        }
        return true;
    }

    public bool ChangePublicDataFlags(int newPublicDataFlags)
    {
        try
        {
            PublicDataFlags flags = (PublicDataFlags)newPublicDataFlags;
            PublicDataFlags = flags;
        }
        catch (InvalidCastException)
        {
            return false;
        }
        return true;
    }
}
