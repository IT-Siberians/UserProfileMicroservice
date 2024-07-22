namespace DataAccess.Entities.ValueObjects.Validation;

public interface IValidator<T>
{
    void Validate(T value);
}
