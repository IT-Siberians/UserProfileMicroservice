namespace DataAccess.Entities.ValueObjects.Validation;

public interface IValidator<T>
{
    bool Validate(T value);
    Exception GetValidationException();
}
