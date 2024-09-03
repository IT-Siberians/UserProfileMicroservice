namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.UsernameValidationExceptions;

public class UsernameIsEmptyException : ArgumentNullException
{
    public override string Message
        => $"{typeof(Username)} cannot be empty.";
}