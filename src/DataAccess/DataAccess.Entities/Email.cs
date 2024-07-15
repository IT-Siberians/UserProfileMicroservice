namespace DataAccess.Entities;

public class Email : ValueObject<String>
{
    public Email(String name)
        : base(name)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
