namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.UsernameValidationExceptions;

public class UsernameMinimumLengthException(string Value, int MinimumLength) : ArgumentOutOfRangeException
{
    public override string Message
        => $"The {typeof(Username)} length of {Value.Length} less then minimum allowed length of {MinimumLength}.";
}
