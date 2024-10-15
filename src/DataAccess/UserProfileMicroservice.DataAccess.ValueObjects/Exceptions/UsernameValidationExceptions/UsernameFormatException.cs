namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.UsernameValidationExceptions;

public class UsernameFormatException(string value, string formatPattern) : FormatException
{
    public string Value => value;
    public string FormatPattern => formatPattern;

    public override string Message
        => $"The {typeof(Username)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
