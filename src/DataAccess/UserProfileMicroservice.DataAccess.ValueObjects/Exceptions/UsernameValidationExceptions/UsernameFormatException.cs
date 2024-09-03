namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.UsernameValidationExceptions;

public class UsernameFormatException(string Value, string FormatPattern) : FormatException
{
    public override string Message
        => $"The {typeof(Username)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
