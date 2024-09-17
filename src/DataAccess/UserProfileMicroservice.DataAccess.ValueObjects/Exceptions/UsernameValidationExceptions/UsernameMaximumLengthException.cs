namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.UsernameValidationExceptions;

public class UsernameMaximumLengthException(string Value, int MaximumLength) : ArgumentOutOfRangeException
{
    public override string Message
        => $"The {typeof(Username)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
