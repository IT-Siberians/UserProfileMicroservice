namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.LastNameValidationExceptions;

public class LastNameFormatException(string value, string formatPattern) : FormatException
{
    public string Value => value;
    public string FormatPattern => formatPattern;

    public override string Message
        => $"The {typeof(LastName)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
