namespace DataAccess.Entities.ValueObjects.Exceptions;

internal static class ExceptionMessages
{
    public const string NEGATIVE_VALUE = "The value cannot be less than zero";
    public const string MAXIMUM_VALUE_EXCEEDED = "Value greater than maximum allowed value";
    public const string VALUE_IS_NULL = "Value cannot be null";
    public const string STRING_IS_EMPTY = "String cannot be empty";
    public const string MAXIMUM_STRING_LENGTH_EXCEEDED = "String length greater than maximum allowed length";
    public const string INVALID_EMAIL_FORMAT = "Invalid email address format";
    public const string INVALID_NAME_CHARACTER_SET = "The name must be Latin only or Cyrillic only";
    public const string INVALID_NAME_CAPITALIZATION = "The name must begin with an uppercase letter and all others must be lowercase";
    public const string INVALID_PHONE_NUMBER_FORMAT = "The phone number must begin with a plus sign and all others characters must be digits";
    public const string INVALID_URL_FORMAT = "Invalid url format";
    public const string USERNAME_LENGTH_LESS_THAN_MINIMUM_VALUE = "The length of the username cannot be less than three alphanumeric characters";
    public const string INVALID_USERNAME_CHARACTER_SET = "The user name can only consist of Latin letters and an underscore character";

}
