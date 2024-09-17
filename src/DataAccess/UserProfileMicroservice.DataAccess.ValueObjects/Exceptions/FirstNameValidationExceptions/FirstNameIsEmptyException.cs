namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.FirstNameValidationExceptions;

public class FirstNameIsEmptyException : ArgumentNullException
{
    public override string Message
        => $"{typeof(FirstName)} cannot be empty.";
}