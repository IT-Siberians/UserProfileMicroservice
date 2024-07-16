namespace DataAccess.Entities;

public class Lastname : ValueObject<String>
{
    public Lastname(string lastname)
        : base(lastname)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
