namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.UsernameValidationExceptions;

public class UsernameMaximumLengthException(string value, int maximumLength) : ArgumentOutOfRangeException
{
    public string Value => value;
    public int MaximumLength => maximumLength;

    public override string Message
        => $"The {typeof(Username)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
