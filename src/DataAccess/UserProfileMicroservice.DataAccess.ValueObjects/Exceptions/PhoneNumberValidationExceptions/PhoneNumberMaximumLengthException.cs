namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.PhoneNumberValidationExceptions;

public class PhoneNumberMaximumLengthException(string Value, int MaximumLength) : ArgumentOutOfRangeException
{
    public override string Message
        => $"The {typeof(PhoneNumber)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
