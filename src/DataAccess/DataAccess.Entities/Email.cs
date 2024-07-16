namespace DataAccess.Entities;

public class Email : ValueObject<String>
{
    public Email(string email)
        : base(email)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
