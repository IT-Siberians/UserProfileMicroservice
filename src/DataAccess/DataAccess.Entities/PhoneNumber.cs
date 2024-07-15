namespace DataAccess.Entities;

public class PhoneNumber : ValueObject<String>
{
    public PhoneNumber(String name)
        : base(name)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
