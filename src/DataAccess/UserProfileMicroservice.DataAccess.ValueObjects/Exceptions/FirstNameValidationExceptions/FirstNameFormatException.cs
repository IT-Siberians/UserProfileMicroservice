namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.FirstNameValidationExceptions;

public class FirstNameFormatException(string value, string formatPattern) : FormatException
{
    public string Value => value;
    public string FormatPattern => formatPattern;

    public override string Message
        => $"The {typeof(FirstName)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
