namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.FirstNameValidationExceptions;

public class FirstNameMaximumLengthException(string value, int maximumLength) : ArgumentOutOfRangeException
{
    public string Value => value;
    public int MaximumLength => maximumLength;

    public override string Message
        => $"The {typeof(FirstName)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
