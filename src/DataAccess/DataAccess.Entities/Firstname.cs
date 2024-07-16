namespace DataAccess.Entities;

public class Firstname : ValueObject<String>
{
    public Firstname(string firstname)
        : base(firstname)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
