namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.LastNameValidationExceptions;

public class LastNameMaximumLengthException(string value, int maximumLength) : ArgumentOutOfRangeException
{
    public string Value => value;
    public int MaximumLength => maximumLength;

    public override string Message
        => $"The {typeof(LastName)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
