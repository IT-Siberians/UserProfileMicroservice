using DataAccess.Entities.ValueObjects.Exceptions;
using DataAccess.Entities.ValueObjects.Validation;

namespace DataAccess.Entities.ValueObjects;

public abstract class ValueObject<T>
{
    private readonly IValidator<T> _validator;
    public T Value { get; }

    public ValueObject(IValidator<T> validator, T value)
    {
        _validator = validator;
        if (_validator == null)
            throw new ValidatorNotSpecifiedException(this);
        if (!_validator.Validate(value))
            throw _validator.GetValidationException();
        Value = value;
    }
}