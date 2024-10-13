namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.EmailValidationExceptions;

public class EmailFormatException(string value, string formatPattern) : FormatException
{
    public string Value => value;
    public string FormatPattern => formatPattern;

    public override string Message
        => $"The {typeof(Email)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
