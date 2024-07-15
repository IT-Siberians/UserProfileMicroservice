namespace DataAccess.Entities;

public class Lastname : ValueObject<String>
{
    public Lastname(String name)
        : base(name)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
