namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.EmailValidationExceptions;

public class EmailMaximumLengthException(string Value, int MaximumLength) : ArgumentOutOfRangeException
{
    public override string Message
        => $"The {typeof(Email)} length of {Value.Length} exceeds the maximum allowed length of {MaximumLength}.";
}
