namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.LastNameValidationExceptions;

public class LastNameIsEmptyException : ArgumentNullException
{
    public override string Message
        => $"{typeof(LastName)} cannot be empty.";
}