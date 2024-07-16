namespace DataAccess.Entities;

public class PhoneNumber : ValueObject<String>
{
    public PhoneNumber(string phoneNumber)
        : base(phoneNumber)
    {
    }

    public override bool Valydate(string value)
    {
        throw new NotImplementedException();
    }
}
