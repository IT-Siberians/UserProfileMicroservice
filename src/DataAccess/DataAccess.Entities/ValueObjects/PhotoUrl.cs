using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public class PhotoUrl : ValueObject<string>
{
    public PhotoUrl(string photoUrl)
        : base(new PhotoUrlValidator(), photoUrl)
    {
    }
}
