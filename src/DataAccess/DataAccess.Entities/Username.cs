namespace DataAccess.Entities;

public class Username : ValueObject<String>
{
    public Username(String name)
        : base(name)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
