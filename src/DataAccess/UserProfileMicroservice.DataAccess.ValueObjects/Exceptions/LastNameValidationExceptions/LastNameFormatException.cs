namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.LastNameValidationExceptions;

public class LastNameFormatException(string Value, string FormatPattern) : FormatException
{
    public override string Message
        => $"The {typeof(LastName)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
