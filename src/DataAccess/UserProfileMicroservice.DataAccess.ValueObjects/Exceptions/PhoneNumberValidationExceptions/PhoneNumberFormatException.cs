namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.PhoneNumberValidationExceptions;

public class PhoneNumberFormatException(string Value, string FormatPattern) : FormatException
{
    public override string Message
        => $"The {typeof(PhoneNumber)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
