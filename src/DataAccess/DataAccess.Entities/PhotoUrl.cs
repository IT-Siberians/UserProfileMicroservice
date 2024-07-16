namespace DataAccess.Entities;

public class PhotoUrl : ValueObject<String>
{
    public PhotoUrl(string photoUrl)
        : base(photoUrl)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
