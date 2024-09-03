namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.FirstNameValidationExceptions;

public class FirstNameFormatException(string Value, string FormatPattern) : FormatException
{
    public override string Message
        => $"The {typeof(FirstName)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
