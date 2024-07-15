namespace DataAccess.Entities;

public class Firstname : ValueObject<String>
{
    public Firstname(String name)
        : base(name)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
