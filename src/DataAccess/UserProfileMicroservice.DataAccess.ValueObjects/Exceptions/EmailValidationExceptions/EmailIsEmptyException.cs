namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.EmailValidationExceptions;

public class EmailIsEmptyException : ArgumentNullException
{
    public override string Message
        => $"{typeof(Email)} cannot be empty.";
}