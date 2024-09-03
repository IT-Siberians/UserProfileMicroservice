namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.EmailValidationExceptions;

public class EmailFormatException(string Value, string FormatPattern) : FormatException
{
    public override string Message
        => $"The {typeof(Email)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
