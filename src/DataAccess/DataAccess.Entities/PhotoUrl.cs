namespace DataAccess.Entities;

public class PhotoUrl : ValueObject<String>
{
    public PhotoUrl(String name)
        : base(name)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
