namespace UserProfileMicroservice.DataAccess.ValueObjects.Exceptions.PhoneNumberValidationExceptions;

public class PhoneNumberFormatException(string value, string formatPattern) : FormatException
{
    public string Value => value;
    public string FormatPattern => formatPattern;

    public override string Message
        => $"The {typeof(PhoneNumber)} value {Value} does not match the format checked by the regular expression pattern {FormatPattern}.";
}
