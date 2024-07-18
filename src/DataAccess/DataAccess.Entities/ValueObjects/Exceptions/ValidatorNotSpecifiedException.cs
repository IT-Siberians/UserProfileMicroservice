namespace DataAccess.Entities.ValueObjects.Exceptions;

public class ValidatorNotSpecifiedException : Exception
{
    public ValidatorNotSpecifiedException(Object obj)
        : base($"Validator must be specified for type {obj.GetType()}")
    {
    }
}