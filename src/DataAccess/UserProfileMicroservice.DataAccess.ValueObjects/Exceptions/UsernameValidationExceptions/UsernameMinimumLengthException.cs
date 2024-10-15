namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.UsernameValidationExceptions;

public class UsernameMinimumLengthException(string value, int minimumLength) : ArgumentOutOfRangeException
{
    public string Value => value;
    public int MinimumLength => minimumLength;

    public override string Message
        => $"The {typeof(Username)} length of {Value.Length} less then minimum allowed length of {MinimumLength}.";
}
