namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.PhoneNumberValidationExceptions;

public class PhoneNumberIsEmptyException : ArgumentNullException
{
    public override string Message
        => $"Value of {typeof(PhoneNumber)} cannot be empty.";
}