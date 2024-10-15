namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.EmailValidationExceptions;

public class EmailMaximumLengthException(string value, int maximumLength) : ArgumentOutOfRangeException
{
    public string Value => value;
    public int MaximumLength => maximumLength;

    public override string Message
        => $"The {typeof(Email)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
