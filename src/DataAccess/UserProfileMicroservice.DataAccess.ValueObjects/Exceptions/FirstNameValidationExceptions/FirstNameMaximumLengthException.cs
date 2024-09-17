namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.FirstNameValidationExceptions;

public class FirstNameMaximumLengthException(string Value, int MaximumLength) : ArgumentOutOfRangeException
{
    public override string Message
        => $"The {typeof(FirstName)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
