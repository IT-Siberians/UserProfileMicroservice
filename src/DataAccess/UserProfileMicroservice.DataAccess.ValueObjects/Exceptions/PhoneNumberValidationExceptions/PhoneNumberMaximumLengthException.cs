namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.PhoneNumberValidationExceptions;

public class PhoneNumberMaximumLengthException(string value, int maximumLength) : ArgumentOutOfRangeException
{
    public string Value => value;
    public int MaximumLength => maximumLength;

    public override string Message
        => $"The {typeof(PhoneNumber)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
