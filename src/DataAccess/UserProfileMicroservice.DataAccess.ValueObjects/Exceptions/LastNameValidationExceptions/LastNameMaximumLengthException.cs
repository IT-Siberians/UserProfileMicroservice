namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.LastNameValidationExceptions;

public class LastNameMaximumLengthException(string Value, int MaximumLength) : ArgumentOutOfRangeException
{
    public override string Message
        => $"The {typeof(LastName)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
